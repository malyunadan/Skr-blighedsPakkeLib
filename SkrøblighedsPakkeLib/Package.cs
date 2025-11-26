namespace SkrøblighedsPakkeLib
{
    public class Package
    {
        public string Id { get; set; }                 // Unikt ID for pakken
        public string Description { get; set; }        // Kort beskrivelse af indhold
        public LimitProfile LimitProfile { get; set; } // Profil der afgør om pakken er skrøbelig
        public List<SensorEvent> SensorEvents { get; set; } = new List<SensorEvent>();

        // Hjælpe-metode til at afgøre om pakken er skrøbelig
        public bool ErSkrøbelig()
        {
            return LimitProfile?.IsFragile ?? false;
        }
    }


}
}
