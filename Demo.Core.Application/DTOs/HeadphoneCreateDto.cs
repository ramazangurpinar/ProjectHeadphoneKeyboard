namespace Demo.Core.Application.DTOs
{
    public class HeadphoneCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageFileName { get; set; }
        public bool Wireless { get; set; }
        public string Manufacturer { get; set; }
        public string Weight { get; set; }
        public string BatteryLife { get; set; }
        public string NoiseCancellationType { get; set; }
        public bool Mic { get; set; }
    }
}
