using testSFD.Models;

namespace testSFD.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Driver GetDriverById(int id);
        void AddDriver(Driver driver);
        void UpdateDriver(Driver driver);
        void DeleteDriver(int id);
        void Save();
    }
}
