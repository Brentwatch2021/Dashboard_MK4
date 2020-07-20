using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Controllers
{
    [Route("api/{version:apiVersion}/vehicle")]
    [ApiController]
    public class Vehicle_Controller : ControllerBase
    {
        private readonly IVehicleDataRepository<Vehicle> _dataRepository;

        public Vehicle_Controller(IVehicleDataRepository<Vehicle> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        
        public IActionResult GetVehicles()
        {
            IEnumerable<Vehicle> vehicles = _dataRepository.GetAll();
            return Ok(vehicles);
        }

        [HttpGet("{id}", Name = "GetVehicle")]
        public IActionResult GetVehicle(Guid id)
        {
            Vehicle vehicle = _dataRepository.Get(id);
            if (vehicle == null)
            {
                return NotFound("The vehicle record couldn't be found.");
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle is null.");
            }

            _dataRepository.Add(vehicle);
            return CreatedAtRoute(
                  "Get",
                  new { Id = vehicle.Vehicle_ID },
                  vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle is Null");
            }

            Vehicle vehicleToUpdate = _dataRepository.Get(id);
            if (vehicleToUpdate == null)
            {
                return NotFound("The Vehicle record couldn't be found.");
            }

            _dataRepository.Update(vehicleToUpdate, vehicle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Vehicle vehicle = _dataRepository.Get(id);
            if (vehicle == null)
            {
                return NotFound("The Vehicle record couldn't be found.");
            }

            _dataRepository.Delete(vehicle);
            return NoContent();
        }


    }
}
