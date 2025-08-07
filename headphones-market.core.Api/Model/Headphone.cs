namespace headphones_market.core.Api.Model;

public class Headphone : Product
{
    public string Manufacturer { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public string BatteryLife { get; set; }
    public string NoiseCancellationType { get; set; }
    public bool Mic { get; set; }
}