using Microsoft.EntityFrameworkCore;
using testSFD.Interfaces;
using testSFD.Models;

namespace testSFD.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly CompanyDataBaseContext _context;

        public DriverRepository(CompanyDataBaseContext context)
        {
            _context = context;
        }

        public void AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
        }

        public void DeleteDriver(int id)
        {
            var driverInDb = _context.Drivers.Find(id);
            if (driverInDb != null)
            {
                _context.Remove(driverInDb);
            }
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public Driver GetDriverById(int id)
        {
            var driverInDb = _context.Drivers.Find(id);
            return driverInDb;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDriver(Driver driver)
        {
            var driverInDb = _context.Drivers.Find(driver.Id);
            if (driverInDb != null)
            {
                //driverInDb.Model = driver.Model;
            }
        }
    }
}
