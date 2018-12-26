using GamblingStat.Models;
using GamblingStat.Properties;
using LanguageExt;
using GamblingStat.Services;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace GamblingStat
{
    public partial class Form1 : Form
    {
        private PredictionService _predictionService;
        private List<PredictionModel> _predictionResults;
        private List<ScoreBoardModel> _scores;
        private const string _selectedColumnName = "Selected";
        private const string _predictionScoreColumnName = "PredictionScore";
        private const string _dragonText = "D";
        private const string _tigerText = "T";

        private const string _winText = "W";
        private const string _loseText = "L";

        private int _dragonPredictionPercentage = 0;
        private int _tigerPredictionPercentage = 0;
        private bool _predictionToggle = false;

        private ChartValues<double> _chartValues = new ChartValues<double>();

        private bool WillWeWin
        {
            get
            {
                var scores = _scores.Where(s => !string.IsNullOrEmpty(s.DrTomResult));

                if (scores.Any())
                {
                    var lastScore = scores.Last();

                    return lastScore.DrTomResult == _winText;
                }

                return true;
            }
        }

        public Form1()
        {
            InitializeComponent();

            dataGridView1.DoubleBuffered(true);
            dataGridView2.DoubleBuffered(true);

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor(),
            };

            var resultPredictor = new DrTom3Predictor();

            _predictionService = new PredictionService(predictors, resultPredictor);

            _scores = new List<ScoreBoardModel>();

            keyValueModelBindingSource.DataSource = new List<KeyValueModel>()
            {
                new KeyValueModel(),
                new KeyValueModel() { Key = _dragonText, Value = _dragonText },
                new KeyValueModel() { Key = _tigerText, Value = _tigerText }
            };

            topPredictionModeComboBox.SelectedIndex = 2;

            winCountNumeric.Maximum = lookBehideNumeric.Value;

            SetupChart();
        }

        private void SetupChart()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Win rate (%)",
                    Values = _chartValues,
                    LineSmoothness = 0,
                    PointGeometrySize = 5
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value =>
                {
                    if (Math.Abs(value % 1) < double.Epsilon)
                        return (value + 1).ToString("0");
                    else
                        return string.Empty;
                }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("0"),
                MaxValue = 80,
                MinValue = 20
            });

            cartesianChart1.Zoom = ZoomingOptions.Y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scoreBoardModelBindingSource.DataSource = _scores;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.Columns[e.ColumnIndex].DataPropertyName == _selectedColumnName)
            {
                dataGridView2.EndEdit();
                UpdatePredictionDataSource();
            }
        }

        private (Func<PredictionModel, bool> selected, Func<PredictionModel, bool> notSelected) GetPredictionCriteria()
        {
            Func<PredictionModel, bool> selectedCriteria = x => true;
            Func<PredictionModel, bool> notSelectedCriteria = x => true;

            switch (topPredictionModeComboBox.SelectedIndex)
            {
                case 0:
                    selectedCriteria = x => x.WinRate == 100;
                    notSelectedCriteria = x => x.WinRate < 100 && x.WinRate >= 50;
                    break;
                case 1:
                    selectedCriteria = x => x.WinRate >= 90;
                    notSelectedCriteria = x => x.WinRate < 90 && x.WinRate >= 50;
                    break;
                case 2:
                    selectedCriteria = x => x.WinRate >= 80;
                    notSelectedCriteria = x => x.WinRate < 80 && x.WinRate >= 50;
                    break;
                case 3:
                    selectedCriteria = x => x.WinRate >= 70;
                    notSelectedCriteria = x => x.WinRate < 70 && x.WinRate >= 50;
                    break;
                case 4:
                    selectedCriteria = x => x.WinRate >= 60;
                    notSelectedCriteria = x => x.WinRate < 60 && x.WinRate >= 50;
                    break;
                case 5:
                    selectedCriteria = x => x.WinRate >= 50;
                    notSelectedCriteria = x => false;
                    break;
                case 6:
                    selectedCriteria = x => x.Selected;
                    notSelectedCriteria = x => !x.Selected && x.WinRate >= 50;
                    break;
            }

            return (selectedCriteria, notSelectedCriteria);
        }

        private void UpdatePredictionDataSource()
        {
            var criteria = GetPredictionCriteria();

            var selectedPredictions = _predictionResults
                .Where(criteria.selected)
                .Select(p => p.PredictionScore);

            _dragonPredictionPercentage = CalculateScorePercentage(_dragonText, selectedPredictions);
            _tigerPredictionPercentage = CalculateScorePercentage(_tigerText, selectedPredictions);

            dragonPredictionButton.Text = $"Bet {_dragonText} : {_dragonPredictionPercentage}%";
            tigerPredictionButton.Text = $"Bet {_tigerText} : {_tigerPredictionPercentage}%";

            topPredictionModelBindingSource.DataSource = _predictionResults
                .Where(criteria.selected)
                .OrderByDescending(p => p.WinRate)
                .ThenBy(p => p.WrongCount)
                .ThenBy(p => p.AlgorithmType);
        }

        private void UpdateGameScoreDataSource()
        {
            var actualScores = _scores
                .Select(s => s.ActualScore);
            actualDragonPercentageLabel.Text = CalculateScorePercentageString(_dragonText, actualScores);
            actualTigerPercentageLabel.Text = CalculateScorePercentageString(_tigerText, actualScores);

            var betScores = _scores
                .Select(s => s.BetScore);
            betDragonPercentageLabel.Text = CalculateScorePercentageString(_dragonText, betScores);
            betTigerPercentageLabel.Text = CalculateScorePercentageString(_tigerText, betScores);

            var betResults = _scores;
            var gameResults = betResults.Select((r, i) =>
            {
                if (string.IsNullOrEmpty(_scores[i].BetScore))
                    return r.WinRate;

                var betResults1 = betResults.Take(i + 1).Where(r1 => !string.IsNullOrEmpty(r1.BetScore))
                    .Select(r1 =>
                    {
                        r1.Result = r1.ActualScore == r1.BetScore ? _winText : _loseText;
                        return r1;
                    });
                return r.WinRate = (int)(betResults1.Where(r1 => r1.Result == _winText).Count() / (float)betResults1.Count() * 100);
            }).ToList();

            _chartValues.Clear();
            _chartValues.AddRange(gameResults.Select(r => r ?? double.NaN));
        }

        private int CalculateScorePercentage(string score, IEnumerable<string> allScores)
        {
            var filteredScores = allScores.Where(s => s == score);
            var selectedPercent = filteredScores
                .Count() / (float)allScores.Where(s => !string.IsNullOrEmpty(s)).Count() * 100;
            return (int)selectedPercent;
        }

        private string CalculateScorePercentageString(string score, IEnumerable<string> allScores)
        {
            var selectedPercent = CalculateScorePercentage(score, allScores);
            return $"{score} : {selectedPercent:0}%";
        }

        private void Recalculate()
        {
            var predictionResults = _predictionService.Predict(
                _scores
                .Select(sb => new GameStateInput(MapScore(sb.ActualScore), MapScore(sb.BetScore))),
                Settings.Default.MappingTableSize,
                (int)lookBehideNumeric.Value);

            var scorePredictions = predictionResults
                .GameStatesWithScorePrediction.Select(pr => 
                (
                    gss: pr.GameStates.Reverse().Skip(1).ToList(),
                    gs: pr.GameStates.Last(),
                    gss2: pr.GameStates,
                    pr.Stat
                ))
                .ToList();

            foreach(var pair in predictionResults.GameStatesWithResultPrediction
                .Zip(_scores))
            {
                var result = from rp in pair.Item1.ResultPrediction
                             from r in rp.Result
                             select r == Services.Domain.Result.Win
                                ? _winText
                                : _loseText;

                var info = from rp in pair.Item1.ResultPrediction
                           from s in rp.Status
                           select s.ToString();

                pair.Item2.DrTomResult = result.IfNone("");
                pair.Item2.DrTomInfo = info.IfNone("");
            }

            var gameStates2 = scorePredictions.SelectMany(pr => pr.gs.ScorePredictions,
                (pr, p) => (pr, prediction: p.Map(x => x.Item2)));

            var predictionResults2 = gameStates2
                .Where(gs => gs.prediction.Name != Constants.MappingTablePredctionName)
                .Select(pr =>
                (
                    ps: pr.prediction.Score,
                    stat: pr.pr.Stat.PredictionStats[pr.prediction.Name],
                    mv: pr.pr.Stat.MappingValue
                ));

            _predictionResults = Map(predictionResults2).ToList();
        }

        private Option<Score> MapScore(string score)
        {
            if (string.IsNullOrEmpty(score))
                return Option<Score>.None;

            return score == _dragonText ? Score.Dragon : Score.Tiger;
        }

        private IEnumerable<PredictionModel> Map(
            IEnumerable<(Score ps, PredictionStat stat, int mv)> list)
        {
            return list
                .Where(pr => pr.stat.Wrong3AndMoreCount == 0)
                .Select(pr => new PredictionModel()
                {
                    PredictionScore = pr.ps == Score.Tiger ? _tigerText : _dragonText,
                    WinRate = pr.stat.WinRate,
                    MappingValue = pr.mv,
                    AlgorithmType = pr.stat.Name,
                    WrongCount = pr.stat.MaxConsecutiveWrong
                });
        }

        private void AddActualScore(string score)
        {
            Cursor.Current = Cursors.WaitCursor;

            scoreBoardModelBindingSource.MoveLast();
            var current = (ScoreBoardModel)scoreBoardModelBindingSource.Current;

            if (current != null && string.IsNullOrEmpty(current.ActualScore))
            {
                current.ActualScore = score;
            }
            else
            {
                scoreBoardModelBindingSource.Add(new ScoreBoardModel()
                {
                    No = _scores.Count + 1,
                    ActualScore = score
                });
            }

            scoreBoardModelBindingSource.ResetCurrentItem();

            Recalculate();
            UpdatePredictionDataSource();
            UpdateGameScoreDataSource();

            scoreBoardModelBindingSource.MoveLast();

            Cursor.Current = Cursors.Default;
        }

        private void dragonButton_Click(object sender, EventArgs e)
        {
            AddActualScore(_dragonText);
        }

        private void tigerButton_Click(object sender, EventArgs e)
        {
            AddActualScore(_tigerText);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (scoreBoardModelBindingSource.Count == 0)
                return;

            scoreBoardModelBindingSource.RemoveAt(scoreBoardModelBindingSource.Count - 1);

            Recalculate();
            UpdatePredictionDataSource();
            UpdateGameScoreDataSource();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            scoreBoardModelBindingSource.Clear();
            topPredictionModelBindingSource.Clear();
            topPredictionModelBindingSource1.Clear();

            dragonPredictionButton.Text = $"Bet {_dragonText} : 0%";
            tigerPredictionButton.Text = $"Bet {_tigerText} : 0%";

            actualDragonPercentageLabel.Text = $"{_dragonText} : 0%";
            actualTigerPercentageLabel.Text = $"{_tigerText} : 0%";

            betDragonPercentageLabel.Text = $"{_dragonText} : 0%";
            betTigerPercentageLabel.Text = $"{_tigerText} : 0%";

            _dragonPredictionPercentage = 0;
            _tigerPredictionPercentage = 0;

            _chartValues.Clear();
        }

        private Color GetScoreColor(string score)
        {
            if (string.IsNullOrEmpty(score))
                return Color.White;

            if (score == _dragonText)
            {
                return Color.Red;
            }
            else
            {
                return Color.Blue;
            }
        }

        private Color GetResultColor(string result)
        {
            if (string.IsNullOrEmpty(result))
                return Color.White;

            if (result == _winText)
            {
                return Color.Green;
            }
            else
            {
                return Color.DarkGray;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1
                || e.ColumnIndex == 2)
            {
                var score = (string)e.Value;
                e.CellStyle.BackColor = GetScoreColor(score);
                e.CellStyle.SelectionBackColor = GetScoreColor(score);
                e.CellStyle.ForeColor = Color.White;
            }
            else if(e.ColumnIndex == 3)
            {
                var result = (string)e.Value;
                e.CellStyle.ForeColor = GetResultColor(result);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            var score = (string)e.Value;
            e.CellStyle.BackColor = GetScoreColor(score);
            e.CellStyle.SelectionBackColor = GetScoreColor(score);
        }

        private void topPredictionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_scores.Any())
            {
                Recalculate();
                UpdatePredictionDataSource();
            }
        }

        private void AddPredictionScore(string predictionScore)
        {
            scoreBoardModelBindingSource.MoveLast();

            var current = (ScoreBoardModel)scoreBoardModelBindingSource.Current;

            if (current != null && string.IsNullOrEmpty(current.ActualScore))
            {
                current.BetScore = predictionScore;
            }
            else
            {
                var newRow = new ScoreBoardModel()
                {
                    No = scoreBoardModelBindingSource.Count + 1,
                    BetScore = predictionScore
                };
                scoreBoardModelBindingSource.Add(newRow);
            }

            scoreBoardModelBindingSource.ResetCurrentItem();
        }

        private void dragonPredictionButton_Click(object sender, EventArgs e)
        {
            AddPredictionScore(_dragonText);
        }

        private void tigerPredictionButton_Click(object sender, EventArgs e)
        {
            AddPredictionScore(_tigerText);
        }

        private void ToggleBorderColor(Button button, Color color)
        {
            if (_predictionToggle)
            {
                button.FlatAppearance.BorderColor = color;
            }
            else
            {
                button.FlatAppearance.BorderColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_dragonPredictionPercentage > _tigerPredictionPercentage)
            {
                ToggleBorderColor(dragonPredictionButton, Color.Red);
                ToggleBorderColor(tigerPredictionButton, Color.White);
            }
            else if(_tigerPredictionPercentage > _dragonPredictionPercentage)
            {
                ToggleBorderColor(dragonPredictionButton, Color.White);
                ToggleBorderColor(tigerPredictionButton, Color.Blue);
            }
            else
            {
                ToggleBorderColor(dragonPredictionButton, Color.Red);
                ToggleBorderColor(tigerPredictionButton, Color.Blue);
            }

            _predictionToggle = !_predictionToggle;
        }

        private void lookBehideNumeric_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            winCountNumeric.Maximum = lookBehideNumeric.Value;
            Recalculate();
            UpdatePredictionDataSource();

            Cursor.Current = Cursors.Default;
        }

        private void winCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Recalculate();
            UpdatePredictionDataSource();

            Cursor.Current = Cursors.Default;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
