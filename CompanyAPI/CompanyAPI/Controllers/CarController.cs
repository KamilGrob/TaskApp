using Microsoft.AspNetCore.Mvc;
using testSFD.Interfaces;

namespace testSFD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allCars = await _carRepository.GetAllCarsAsync();
            return Json(allCars);
        }

        [HttpGet("{carId}")]
        public IActionResult GetCarById(int carId)
        {
            try
            {
                var car = _carRepository.GetCarById(carId);
                return Json(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error, contact the administrator");
            }
        }
        [HttpPost]
        public IActionResult AddCar(Models.Car newCar)
        {
            _carRepository.AddCar(newCar);
            _carRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCar(Models.Car newCar)
        {
            _carRepository.UpdateCar(newCar);
            _carRepository.Save();
            return Ok();
        }
        [HttpDelete("{carId}")]
        public IActionResult DeleteCar(int carId)
        {
            _carRepository.DeleteCar(carId);
            _carRepository.Save();
            return Ok();
        }
    }
}
