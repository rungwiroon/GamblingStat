using GamblingStat.Models;
using Services;
using Services.Domain;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingStat
{
    public class Service
    {
        private PredictionService _predictionService;
        private List<PredictionModel> _predictionResults;
        private List<ScoreBoardModel> _scores;
        private List<GameStateOutput> _gameStates;

        private const string _dragonText = "D";
        private const string _tigerText = "T";

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

        private void Recalculate(int lookBehideLimit, int mappingTableSize)
        {
            var predictionResults = _predictionService.Predict(
                _gameStates
                .Skip(_scores.Count - lookBehideLimit),
                mappingTableSize)
                .Select(pr =>
                (
                    gss: pr.gameStates.Reverse().Skip(1).ToList(),
                    gs: pr.gameStates.Last(),
                    pr.stat
                ))
                .ToList();

            var gameStates2 = predictionResults.SelectMany(pr => pr.gs.ScorePredictions,
                (pr, p) => (pr, prediction: p.Map(x => x.Item2)));

            var predictionResults2 = gameStates2
                .Where(gs => gs.prediction.Name != Constants.MappingTablePredctionName)
                .Select(pr =>
                (
                    ps: pr.prediction.Score,
                    stat: pr.pr.stat.PredictionStats[pr.prediction.Name],
                    mv: pr.pr.stat.MappingValue
                ));

            _predictionResults = MapPredictionScore(predictionResults2).ToList();
        }

        private IEnumerable<PredictionModel> MapPredictionScore(
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
    }
}
