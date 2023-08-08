using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApp_REST_api.Data;
using RentApp_REST_api.Models;
using RentApp_REST_api.Models.Dto;

namespace RentApp_REST_api.Controllers
{
    [ApiController]
    [Route("/api/cars")]
    public class CarAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CarAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CarDTO>> GetCars()
        {
            return Ok(_db.Cars);
        }

        [HttpGet("{id:int}", Name = "GetCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDTO> GetCarById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var car = _db.Cars.FirstOrDefault(u => u.Id == id);

            if(car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CarDTO> CreateCar([FromBody]CarDTO carDto)
        {
            if(_db.Cars.FirstOrDefault(u => u.Model.ToLower() == carDto.Model.ToLower()) != null)
            {
                ModelState.AddModelError("", "Model already Exists!");
                return BadRequest(ModelState);
            }

            if(carDto == null) 
            {
            return BadRequest();  
            }
            
            if(carDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Car model = new()
            {
                Id = carDto.Id,
                Brand = carDto.Brand,
                Model = carDto.Model,
                Year = carDto.Year,
                HorsePower = carDto.HorsePower,
                Description = carDto.Description,
                Details = carDto.Details,
                ImageUrl = carDto.ImageUrl,
                Price = carDto.Price,
                Rating  = carDto.Rating,
            };

            _db.Cars.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetCar", new {id = carDto.Id }, carDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteCar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCar(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            var car = _db.Cars.FirstOrDefault(u => u.Id == id);
            if(car == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(car);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateCar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCar(int id, [FromBody]CarDTO carDto)
        {
            if(carDto == null || id != carDto.Id)
            {
                return BadRequest();
            }

            Car model = new()
            {
                Id = carDto.Id,
                Brand = carDto.Brand,
                Model = carDto.Model,
                Year = carDto.Year,
                HorsePower = carDto.HorsePower,
                Description = carDto.Description,
                Details = carDto.Details,
                ImageUrl = carDto.ImageUrl,
                Price = carDto.Price,
                Rating = carDto.Rating,
            };

            _db.Cars.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialCar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialCar(int id, JsonPatchDocument<CarDTO> patchDto)
        {
            if(patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var car = _db.Cars.AsNoTracking().FirstOrDefault(u => u.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            CarDTO carModel = new()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                HorsePower = car.HorsePower,
                Description = car.Description,
                Details = car.Details,
                ImageUrl = car.ImageUrl,
                Price = car.Price,
                Rating = car.Rating,
            };

            patchDto.ApplyTo(carModel, ModelState);

            Car model = new Car()
            {
                Id = carModel.Id,
                Brand = carModel.Brand,
                Model = carModel.Model,
                Year = carModel.Year,
                HorsePower = carModel.HorsePower,
                Description = carModel.Description,
                Details = carModel.Details,
                ImageUrl = carModel.ImageUrl,
                Price = carModel.Price,
                Rating = carModel.Rating,
            };

            _db.Cars.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
