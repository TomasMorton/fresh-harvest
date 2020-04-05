module FreshHarvest.Domain.Types

open System

module Seeds =
    type SunlightRequirement =
        | Full
        | Shade
        | None

    type WateringInfo =
        { FreqInDays: int
          VolumeInMl: int }

    type PlantingInfo =
        { IdealDate: DateTime
          DepthInCm: int
          DistanceInCm: int }

    type Seed =
        { DaysToSprout: int
          Planting: PlantingInfo
          Watering: WateringInfo
          Sunlight: SunlightRequirement }
