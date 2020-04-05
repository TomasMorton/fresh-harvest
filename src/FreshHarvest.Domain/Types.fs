module FreshHarvest.Domain.Types

module Seeds =
    type WateringInfo =
        { FreqInDays: int }

    type Seed =
        { Watering: WateringInfo }
