module FreshHarvest.Domain.Queries

open FreshHarvest.Domain.Types
open System

module SeedQueries =
    open Seeds

    let dateToExpectSprouting (plantedDate: DateTime) seed =
        let daysToSprout =
            seed.DaysToSprout
            |> float
            |> TimeSpan.FromDays
        plantedDate.Add daysToSprout

    let needsWateringToday clock (plantedDate: DateTime) seed =
        //todo: could fail if plantedDate is before today - or just return false
        let today = clock()
        let daysGrown = (today - plantedDate).TotalDays |> int
        daysGrown % seed.Watering.FreqInDays = 0

    module PotSizes =
        let private isPotDeepEnough potDepth seed =
            //TODO: maybe the depth you plant at and the depth it grows to need to be separate fields?
            seed.Planting.DepthInCm < potDepth

        let private isPotWideEnough potWidth seed =
            seed.Planting.DistanceInCm <= potWidth

        let private isPotLongEnough potLength seed =
            seed.Planting.DistanceInCm <= potLength

        let isPotBigEnough potLength potWidth potDepth seed =
            isPotLongEnough potLength seed && isPotWideEnough potWidth seed && isPotDeepEnough potDepth seed

        let private howManySeedsFitLengthwise potLength seed =
            potLength / seed.Planting.DistanceInCm

        let private howManySeedsFitWidthwise potWidth seed =
            potWidth / seed.Planting.DistanceInCm

        let howManySeedsFit potLength potWidth seed =
            howManySeedsFitLengthwise potLength seed * howManySeedsFitWidthwise potWidth seed
