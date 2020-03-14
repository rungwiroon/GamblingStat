module Domain

open System.Collections.Generic

type Side = Tiger | Dragon

type Result = Win | Lose

type Actual = {
    Bet: Side option;
    Issued: Side option;
} with
    member this.Result = this.Bet = this.Issued

type PredictionAlgorithm = SD | Anti1 | Anti2

type PredictionResult = {
    Predicted: Side;
    Result: Result option;
}

type Game = Game of int

type SdPrediction = PredictionResult
type Anti1Prediction = PredictionResult
type Anti2Prediction = PredictionResult

type Output = {
    Index: int;
    Actual: Actual;
    SdPrediction: SdPrediction;
    Anti1Prediction: Anti1Prediction;
    Anti2Prediction: Anti2Prediction;
}