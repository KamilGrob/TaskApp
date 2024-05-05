using Microsoft.AspNetCore.Mvc;
using testSFD.Interfaces;
using testSFD.Repositories;

namespace testSFD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripRepository _tripRepository;
        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try { 
                var alTrips = await _tripRepository.GetAllTripsAsync();
                return Json(alTrips);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error, contact the administrator");
            }
        }
        [HttpGet("{tripId}")]
        public IActionResult GetTripById(int tripId)
        {
            var trip = _tripRepository.GetTripById(tripId);
            return Json(trip);
        }
        [HttpPost]
        public IActionResult AddTrip(Models.Trip newTrip)
        {
            if (_tripRepository.CheckLicense(newTrip))
            {
                _tripRepository.AddTrip(newTrip);
                _tripRepository.Save();
                return Ok();
            }else return BadRequest();
            
        }
        [HttpPut]
        public IActionResult UpdateTrip(Models.Trip newTrip)
        {
            _tripRepository.UpdateTrip(newTrip);
            _tripRepository.Save();
            return Ok();
        }
        [HttpDelete("{tripId}")]
        public IActionResult DeleteTrip(int tripId)
        {
            _tripRepository.DeleteTrip(tripId);
            _tripRepository.Save();
            return Ok();
        }
    }
}
