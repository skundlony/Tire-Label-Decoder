using Newtonsoft.Json;

namespace Tire_Label_Decoder.Types
{
    public class TireLabel
    {
        [JsonProperty("tyreClass")]
        public string TireClass { get; set; }

        [JsonProperty("modelIdentifier")]
        public string Eprel { get; set; }

        [JsonProperty("supplierOrTrademark")]
        public string Brand { get; set; }

        [JsonProperty("commercialName")]
        public string Model { get; set; }

        [JsonProperty("tyreSection")]
        public int Width { get; set; }

        [JsonProperty("aspectRatio")]
        public int Sidewall { get; set; }

        [JsonProperty("rimDiameter")]
        public int Diameter { get; set; }

        [JsonProperty("externalRollingNoiseValue")]
        public string NoiseRating { get; set; }

        [JsonProperty("externalRollingNoiseClass")]
        public string NoiseClass { get; set; }

        [JsonProperty("speedCategorySymbol")]
        public string SpeedIndex { get; set; }

        [JsonProperty("loadCapacityIndex")]
        public int LoadCapacityIndex { get; set; }

        [JsonProperty("wetGripClass")]
        public string WetGrip { get; set; }

        [JsonProperty("energyClass")]
        public string FuelEfficiency { get; set; }

        [JsonProperty("severeSnowTyre")]
        public bool SnowTire { get; set; }
    }
}