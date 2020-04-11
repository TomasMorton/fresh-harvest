module FreshHarvest.Domain.Types

module Plants =
    type Plant =
        { Name: string }

module Seeds =
    type WateringInfo =
        { FreqInDays: int }

    type Seed =
        { Watering: WateringInfo }
