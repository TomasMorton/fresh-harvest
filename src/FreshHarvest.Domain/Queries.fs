module FreshHarvest.Domain.Queries

open System

module Seeds =
    open Types.Seeds

    let needsWateringToday clock (plantedAt: DateTime) seed =
        let age = (clock() - plantedAt).TotalDays |> int
        if age >= 0 then age % seed.Watering.FreqInDays = 0
        else false
