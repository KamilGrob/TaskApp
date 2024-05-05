using Microsoft.EntityFrameworkCore;
using testSFD.Models;

namespace testSFD
{
    public class CompanyDataBaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public CompanyDataBaseContext(DbContextOptions options) : base(options) { }

    }
}
