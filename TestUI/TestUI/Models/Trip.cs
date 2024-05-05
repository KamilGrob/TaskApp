using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }
        public double AverageFuelConsumption { get; set; }

    }
}
