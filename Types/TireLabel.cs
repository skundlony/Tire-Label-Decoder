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

    public class TireLabel
    {
        public string Eprel { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Width { get; set; }
        public int Sidewall { get; set; }
        public int Diameter { get; set; }
        public int NoiseRating { get; set; }
        public Index WetGrip { get; set; }
        public Index FuelEfficiency { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Eprel} {Width}/{Sidewall}/{Diameter} {NoiseRating}, {WetGrip}, {FuelEfficiency},";
        }
    }
}