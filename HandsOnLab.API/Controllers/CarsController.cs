using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarBL _carBL;
        public CarsController(ICarBL carBL)
        {
            _carBL = carBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> GetCars()
        {
            var cars = _carBL.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<CarDTO> GetCarById(int id)
        {
            var car = _carBL.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        //insert
        [HttpPost]
        public ActionResult<CarDTO> AddCar(CarInsertDTO carInsertDto)
        {
            try
            {
                if (carInsertDto == null)
                {
                    return BadRequest("Car data is null.");
                }
                var addedCar = _carBL.AddCar(carInsertDto);
                return CreatedAtAction(nameof(GetCarById), new { id = addedCar.CarId }, addedCar);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<CarDTO> UpdateCar(int id, CarUpdateDTO carUpdateDto)
        {
            if (id != carUpdateDto.CarId)
            {
                return BadRequest("Car ID mismatch.");
            }

            try
            {
                var updatedCar = _carBL.UpdateCar(carUpdateDto);
                return Ok(updatedCar);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            try
            {
                _carBL.DeleteCar(id);
                return Ok($"Car id: {id} deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
