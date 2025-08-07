namespace Demo.Core.Application.DTOs
{
    public class HeadphoneCreateDto: ProductBaseDto
    {
        public string Manufacturer { get; set; }
        public string BatteryLife { get; set; }
        public string NoiseCancellationType { get; set; }
        public bool Mic { get; set; }
    }
}
