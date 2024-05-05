using testSFD.Models;

namespace testSFD.Interfaces
{
    public interface ICarRepository
    {
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        void Save();
        Task<IEnumerable<Car>> GetAllCarsAsync();
    }
}
