﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Domain;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass]
    public class DrTom2PredictorTest
    {
        [TestMethod]
        public void initial_status_should_be_one()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13);
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for(int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.One, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void if_result_not_changed_stay_at_one()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 14);
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.One, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultChanged_ThenStatusShouldStillSameAsLastStatus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.One, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Lose, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultChangedAgainAfterChanged_ThenStatusShouldChangeToTwoWithCMinusAsDefault()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.Two, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultNoChangedAfterChanged_ThenStatusShouldChangeToOne()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 2));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.One, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Lose, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultNotChangedAfterTwoStatus_ThenStatusShouldChangedToCMinus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 2));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CMinus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultChangedOnceOnOneStatus_ThenStatusShouldStillOne()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 3));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.One, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Lose, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultChanged3Times_ThenStatusShouldChangedToCPlus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CPlus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultChanged4Times_ThenStatusShouldStillCPlus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CPlus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Lose, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultSame2TimesAfterCPlus_ThenStatusShouldChangedCMinus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 2));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CMinus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultSame2TimesAfterCMinus_ThenStatusShouldChangedCMinus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 2))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 2));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CMinus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Lose, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }

        [TestMethod]
        public void WhenResultDifferent3TimesAfterCMinus_ThenStatusShouldChangedCPlus()
        {
            var inputs = Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 13)
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 2))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Dragon), 1))
                .Concat(Enumerable.Repeat(new GameStateInput(Score.Dragon, Score.Tiger), 1));
            var predictor = new DrTom2Predictor();
            var outputs = inputs.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = predictor.Predict(outputs, i);
                outputs[i] = output;
            }

            Assert.AreEqual(DrTom2Status.CPlus, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Status);
            Assert.AreEqual(Result.Win, outputs.Last().ResultPrediction.IfNoneUnsafe(() => null).Result);
        }
    }
}
