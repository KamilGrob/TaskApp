using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<LicenseCategory> LicenseCategories { get; set; }
        public Driver()
        {
            LicenseCategories = new List<LicenseCategory>();
        }
    }

    public enum LicenseCategory
    {
        A,
        B,
        C,
        D
    }
    
}
