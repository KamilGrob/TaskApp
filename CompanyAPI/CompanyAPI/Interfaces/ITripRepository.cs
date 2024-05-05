using testSFD.Models;

namespace testSFD.Interfaces
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Trip GetTripById(int id);
        void AddTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int id);
        void Save();
        bool CheckLicense(Trip trip);
    }
}
