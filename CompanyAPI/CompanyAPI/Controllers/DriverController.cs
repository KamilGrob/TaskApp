using Microsoft.AspNetCore.Mvc;
using testSFD.Interfaces;
using testSFD.Repositories;

namespace testSFD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try {
                var allDrivers = await _driverRepository.GetAllDriversAsync();
                return Json(allDrivers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error, contact the administrator");
            }
        } 
        [HttpGet("{driverId}")]
        public IActionResult GetDriverById(int driverId)
        {
            var driver = _driverRepository.GetDriverById(driverId);
            return Json(driver);
        }
        [HttpPost]
        public IActionResult AddDriver(Models.Driver newDriver)
        {
            _driverRepository.AddDriver(newDriver);
            _driverRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDriver(Models.Driver newDriver)
        {
            _driverRepository.UpdateDriver(newDriver);
            _driverRepository.Save();
            return Ok();
        }
        [HttpDelete("{driverId}")]
        public IActionResult DeleteDriver(int driverId)
        {
            _driverRepository.DeleteDriver(driverId);
            _driverRepository.Save();
            return Ok();
        }
    }
}
