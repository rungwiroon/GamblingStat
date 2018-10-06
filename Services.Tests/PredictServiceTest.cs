using System;
using System.Diagnostics;
using System.Linq;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Domain;
using Services.Predictors;

namespace Services.Tests
{
    [TestClass]
    public class PredictServiceTest
    {
        [TestMethod]
        public void WhenRunWithAllPossibleMapping_ShouldHavePredictResult()
        {
            var scores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                //Score.Tiger,
            };

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor()
            };

            var predictService = new PredictionService(predictors);
            var tableSize = 8;
            var result = predictService.Predict(scores, tableSize)
                .ToList();

            Assert.AreEqual((int)Math.Pow(2, tableSize), result.Count());
            Assert.AreEqual(scores.Count() + 1, result.First().gameStates.Count());

            Debug.WriteLine("Best mt");
            foreach (var bestPredict in result
                //.Select(r => r.stat.SameDiffPredictionStat)
                .OrderBy(s => s.stat.MappingTablePredictionStat.Wrong3AndMoreCount)
                .ThenBy(s => s.stat.MappingTablePredictionStat.Wrong2Count)
                .ThenBy(s => s.stat.MappingTablePredictionStat.Wrong1Count)
                .ThenByDescending(s => s.stat.MappingTablePredictionStat.WinRate)
                //.OrderByDescending(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                .Take(5))
            {
                Debug.WriteLine($"{bestPredict.gameStates.Last()}\t{bestPredict.stat}");
            }
            Debug.WriteLine("");

            Debug.WriteLine("Best sd");
            foreach (var bestPredict in result
                //.Select(r => r.stat.SameDiffPredictionStat)
                .OrderBy(s => s.stat.SameDiffPredictionStat.Wrong3AndMoreCount)
                .ThenBy(s => s.stat.SameDiffPredictionStat.Wrong2Count)
                .ThenBy(s => s.stat.SameDiffPredictionStat.Wrong1Count)
                .ThenByDescending(s => s.stat.SameDiffPredictionStat.WinRate)
                //.OrderByDescending(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                .Take(5))
            {
                Debug.WriteLine($"{bestPredict.gameStates.Last()}\t{bestPredict.stat}");
            }
            Debug.WriteLine("");

            Debug.WriteLine("Best a12");
            foreach (var bestPredict in result
                //.Select(r => r.stat.Anti12PredictionStat)
                //.OrderBy(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                //.ThenByDescending(s => s.WinRate)
                //.OrderByDescending(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                .OrderBy(s => s.stat.Anti12PredictionStat.Wrong3AndMoreCount)
                .ThenBy(s => s.stat.Anti12PredictionStat.Wrong2Count)
                .ThenBy(s => s.stat.Anti12PredictionStat.Wrong1Count)
                .ThenByDescending(s => s.stat.Anti12PredictionStat.WinRate)
                .Take(5))
            {
                Debug.WriteLine($"{bestPredict.gameStates.Last()}\t{bestPredict.stat}");
            }
            Debug.WriteLine("");

            Debug.WriteLine("Best a2");
            foreach (var bestPredict in result
                //.Select(r => r.stat.Anti2PredictionStat)
                //.OrderBy(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                //.ThenByDescending(s => s.WinRate)
                //.OrderByDescending(s => s.MoreThan1ConsecutiveWrongPredictionCount)
                .OrderBy(s => s.stat.Anti2PredictionStat.Wrong3AndMoreCount)
                .ThenBy(s => s.stat.Anti2PredictionStat.Wrong2Count)
                .ThenBy(s => s.stat.Anti2PredictionStat.Wrong1Count)
                .ThenByDescending(s => s.stat.Anti2PredictionStat.WinRate)
                .Take(5))
            {
                Debug.WriteLine($"{bestPredict.gameStates.Last()}\t{bestPredict.stat}");
            }
            Debug.WriteLine("");
        }

        [TestMethod]
        public void WhenRunWithSpecificMapping_ShouldHavePredictResult()
        {
            var scores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
            };

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor()
            };

            var predictService = new PredictionService(predictors);
            var mappingScores = new Score[]
            {
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger
            };
            var result = predictService.Predict2(scores, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var predictResult = result.Last();
            Assert.AreEqual(Score.Dragon, predictResult.MappingTablePredictScore);
            Assert.AreEqual(Score.Dragon, predictResult.SameDiffPredictScore);
            Assert.AreEqual(Score.Dragon, predictResult.Anti12PredictScore);
            Assert.AreEqual(Score.Tiger, predictResult.Anti2PredictScore);
        }

        [TestMethod]
        public void WhenRunWithSameScoreAndMapping_ShouldHave100PercentPredictResult()
        {
            var scores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Dragon
            };

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor()
            };

            var predictService = new PredictionService(predictors);
            var mappingScores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Tiger,
                Score.Dragon,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Dragon
            };
            var result = predictService.Predict2(scores, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var stat = StatService.Calculate(result
                .Where(r => r.ActualScore.IsSome)
                .Select(r => r.SameDiffPredictResult)
                .Where(r => r.IsSome)
                .Select(r => r.IfNone(Result.Lose)));

            Assert.AreEqual(100, stat.WinRate);
        }
    }
}
