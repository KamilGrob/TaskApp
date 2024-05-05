using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI.Models
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
