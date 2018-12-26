using System;
using System.Diagnostics;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using GamblingStat.Services;

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

            var resultPredictor = new DummyPredictor();

            var predictService = new PredictionService(predictors, resultPredictor);
            var tableSize = 8;
            var result = predictService.Predict(scores.Select(x => new GameStateInput(x, None)), tableSize, 15)
                .GameStatesWithScorePrediction
                .ToList();

            Assert.AreEqual((int)Math.Pow(2, tableSize), result.Count());
            Assert.AreEqual(scores.Count() + 1, result.First().GameStates.Count());
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

            var resultPredictor = new DummyPredictor();

            var predictService = new PredictionService(predictors, resultPredictor);
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

            var gameStates = scores.Select(s => new GameStateInput(s, None));

            var result = predictService.PredictScore(gameStates, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var predictResult = result.Last();
            Assert.AreEqual(Score.Dragon, predictResult.ScorePredictions.Find(Constants.MappingTablePredctionName).Map(x => x.Score));
            Assert.AreEqual(Score.Dragon, predictResult.ScorePredictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score));
            Assert.AreEqual(Score.Tiger, predictResult.ScorePredictions.Find(Constants.Anti12PredictionName).Map(x => x.Score));
            Assert.AreEqual(Score.Dragon, predictResult.ScorePredictions.Find(Constants.Anti2PredictionName).Map(x => x.Score));
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

            var resultPredictor = new DummyPredictor();

            var predictService = new PredictionService(predictors, resultPredictor);
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

            var gameStates = scores.Select(s => new GameStateInput(s, None));

            var result = predictService.PredictScore(gameStates, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var sdResult = result
                    .Select(r => r.ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(p => p.Result))
                    .Where(r => r.IsSome)
                    .Map(r => r.IfNone(Result.Lose));

            var stat = StatService.Calculate(
                Constants.SameDiffPredictionName,
                sdResult);

            Assert.AreEqual(100, stat.WinRate);
        }

        [TestMethod]
        public void WhenRunWithAllDragon_ShouldHave100PercentPredictResult()
        {
            var scores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon
            };

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor()
            };

            var resultPredictor = new DummyPredictor();

            var predictService = new PredictionService(predictors, resultPredictor);
            var mappingScores = new Score[]
            {
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon,
                Score.Dragon
            };

            var gameStates = scores.Select(s => new GameStateInput(s, None));

            var result = predictService.PredictScore(gameStates, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var sdResult = result
                    .Select(r => r.ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(p => p.Result))
                    .Where(r => r.IsSome)
                    .Map(r => r.IfNone(Result.Lose));

            var stat = StatService.Calculate(
                Constants.SameDiffPredictionName,
                sdResult);

            Assert.AreEqual(100, stat.WinRate);
        }

        [TestMethod]
        public void WhenRunWithAllTiger_ShouldHave100PercentPredictResult()
        {
            var scores = new Score[]
            {
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger
            };

            var predictors = new IPredictor[]
            {
                new SameDifferentPredictor(),
                new Anti12Predictor(),
                new Anti2Predictor()
            };

            var resultPredictor = new DummyPredictor();

            var predictService = new PredictionService(predictors, resultPredictor);
            var mappingScores = new Score[]
            {
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger,
                Score.Tiger
            };

            var gameStates = scores.Select(s => new GameStateInput(s, None));

            var result = predictService.PredictScore(gameStates, mappingScores)
                .ToList();

            Assert.AreEqual(scores.Count() + 1, result.Count());

            var sdResult = result
                    .Select(r => r.ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(p => p.Result))
                    .Where(r => r.IsSome)
                    .Map(r => r.IfNone(Result.Lose));

            var stat = StatService.Calculate(
                Constants.SameDiffPredictionName,
                sdResult);

            Assert.AreEqual(100, stat.WinRate);
        }
    }
}
