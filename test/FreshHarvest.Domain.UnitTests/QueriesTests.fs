module QueriesTests

open System
open FsCheck
open FsCheck.Xunit

module Seeds =
    module Watering =
        open FreshHarvest.Domain.Types.Seeds
        open FreshHarvest.Domain.Queries.Seeds
        
        let daysBetween (from : DateTime) (``to``: DateTime) =
            (``to`` - from).TotalDays |> int
        
        [<Property>]
        let ``needsWateringToday should return true when the plant needs watering today``
            (seed : Seed)
            (plantedAt: DateTime)
            (frequency: int)
            (multiplier: int) =
            (frequency > 0 && multiplier > 0) ==> lazy
                              
            let seed = { seed with Watering = { seed.Watering with FreqInDays = frequency } }                          
            let clock () = plantedAt.AddDays(float (frequency * multiplier))
            
            let actual = needsWateringToday clock plantedAt seed
            
            actual = true
            
        [<Property>]
        let ``needsWateringToday should return false when the plant doesn't need watering today``
            (seed : Seed)
            (plantedAt: DateTime)
            (now: DateTime) =
            ((now >= plantedAt) &&
             (seed.Watering.FreqInDays > 0) &&
             ((daysBetween now plantedAt) % seed.Watering.FreqInDays <> 0)) ==> lazy
                                                        
            let clock () = now
            
            let actual = needsWateringToday clock plantedAt seed
            
            actual = false

        [<Property>]
        let ``needsWateringToday should return false when it hasn't been planted yet``
            (seed : Seed)            
            (plantedAt: DateTime)
            (now: DateTime) =
            ((now <= plantedAt) &&
             (seed.Watering.FreqInDays > 0)) ==> lazy
                                                        
            let clock () = now
            
            let actual = needsWateringToday clock plantedAt seed
            
            actual = false