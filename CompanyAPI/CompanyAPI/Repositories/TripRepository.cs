using Microsoft.EntityFrameworkCore;
using testSFD.Interfaces;
using testSFD.Models;

namespace testSFD.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly CompanyDataBaseContext _context;

        public TripRepository(CompanyDataBaseContext context)
        {
            _context = context;
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
        }

        public bool CheckLicense(Trip trip)
        {
            var carInDb = _context.Cars.Find(trip.CarId);
            var driverInDb = _context.Drivers.Find(trip.DriverId);
            if (carInDb != null && driverInDb != null)
            {
                if (carInDb.Type == CarType.Bus && driverInDb.LicenseCategories.Contains(LicenseCategory.D)) return true;
                else if (carInDb.Type == CarType.Heavy && driverInDb.LicenseCategories.Contains(LicenseCategory.C)) return true;
                else if (carInDb.Type == CarType.Motorcycle && driverInDb.LicenseCategories.Contains(LicenseCategory.A)) return true;
                else if (carInDb.Type == CarType.Passenger && driverInDb.LicenseCategories.Contains(LicenseCategory.B)) return true;
                else return false;
            }
            else return false;
            
        }

        public void DeleteTrip(int id)
        {
            var tripInDb = _context.Trips.Find(id);
            if (tripInDb != null)
            {
                _context.Remove(tripInDb);
            }
        }
        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public Trip GetTripById(int id)
        {
            var tripInDb = _context.Trips.Find(id);
            return tripInDb;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTrip(Trip trip)
        {
            var tripInDb = _context.Trips.Find(trip.Id);
            if (tripInDb != null)
            {
                //tripInDb.Model = car.Model;
            }
        }
    }
}
