module FreshHarvest.Domain.UnitTests.ResultHelper

let isSuccess actual =
    match actual with
    | Ok _ -> true
    | Error _ -> false

let isFailure actual =
    not (isSuccess actual)
