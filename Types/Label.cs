namespace Tire_Label_Decoder.Types
{
    public enum Index
    {
        A,
        B,
        C,
        D,
        E
    }

    public enum Season
    {
        SUMMER,
        WINTER,
        ALL
    }

    public class Label
    {
        public string Eprel { get; set; }
        public string Brand { get; set; }
        public int Width { get; set; }
        public int Sidewall { get; set; }
        public int Diameter { get; set; }
        public int NoiseRating { get; set; }
        public Index WetGrip { get; set; }
        public Index FuelEfficiency { get; set; }

        internal string GetSize()
        {
            return $"{Width}/{Sidewall}/{Diameter}";
        }
    }
}