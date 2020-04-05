module FreshHarvest.Domain.Types

open System

module Seeds =
    type SunlightRequirement =
        | Full
        | Half
        | Shade

    type SoilType =
        | Sand
        | Dirt

    type WateringInfo =
        { FreqInDays: int
          VolumeInMl: int }

    type StartingInfo =
        { IdealDate: DateTime
          DepthInCm: int }

    type PlantingInfo =
        { IdealDate: DateTime
          DepthInCm: int
          DistanceInCm: int
          Soil: SoilType }

    type Seed =
        { DaysToSprout: int
          Starting: StartingInfo option
          Planting: PlantingInfo
          Watering: WateringInfo
          Sunlight: SunlightRequirement }
