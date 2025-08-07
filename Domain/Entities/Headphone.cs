namespace Demo.Core.Domain.Entities
{
    public class Headphone : Product
    {
        public string Manufacturer { get; set; }
        public string BatteryLife { get; set; }
        public string NoiseCancellationType { get; set; }
        public bool Mic { get; set; }
    }
}
