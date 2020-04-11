module FreshHarvest.Domain.Queries

open System

module Plants =
    open Types.Plants
    
    let browsePlants (listPlants) =
        let getNames = List.map (fun p -> p.Name)
        
        listPlants ()
        |> Result.map getNames
        
module Seeds =
    open Types.Seeds

    let needsWateringToday clock (plantedAt: DateTime) seed =
        let age = (clock() - plantedAt).TotalDays |> int
        if age >= 0 then age % seed.Watering.FreqInDays = 0
        else false
