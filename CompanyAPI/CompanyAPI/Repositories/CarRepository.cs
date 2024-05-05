using Microsoft.EntityFrameworkCore;
using testSFD.Interfaces;
using testSFD.Models;

namespace testSFD.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CompanyDataBaseContext _context;

        public CarRepository(CompanyDataBaseContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            var carInDb = _context.Cars.Find(id);
            if (carInDb != null)
            {
               _context.Remove(carInDb);
            }
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public Car GetCarById(int id)
        {
            var carInDb = _context.Cars.Find(id);
            return carInDb;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            var carInDb = _context.Cars.Find(car.Id);
            if (carInDb != null)
            {
                carInDb.Model = car.Model;
                carInDb.Brand = car.Brand;
                carInDb.RegistrationNumber = car.RegistrationNumber;
                carInDb.Type = car.Type;
            }
        }
    }
}
