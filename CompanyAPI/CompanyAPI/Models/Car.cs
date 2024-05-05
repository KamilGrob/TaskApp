namespace testSFD.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string RegistrationNumber { get; set; }
        public CarType Type { get; set; }

    }

    public enum CarType
    {
        Motorcycle,
        Passenger,
        Heavy,
        Bus
    }
}
