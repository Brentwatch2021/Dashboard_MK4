using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard_MK4.Models.N_S_Models.NS_H20;
using Dashboard_MK4.Models.NS_Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard_MK4.Controllers
{
    [Route("api/{version:apiVersion}/NS_H20")]
    [ApiController]
    public class H20_Controller : ControllerBase
    {
        private readonly INS_H20_Repository<NS_H20> _dataRepository;

        public H20_Controller(INS_H20_Repository<NS_H20> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/{version:apiVersion}/H20
        [HttpGet]
        public IActionResult Get()
        {    
            IEnumerable<NS_H20> h20s = _dataRepository.GetAll().ToList();
            return Ok(h20s);
        }

        // GET api/{version:apiVersion}/H20/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            NS_H20 h20 = _dataRepository.Get(id);
            if (h20 == null)
            {
                return NotFound("The H20 record couldn't be found.");
            }
            return Ok(h20);
        }

        // POST  api/{version:apiVersion}/H20/
        [HttpPost]
        public IActionResult Post([FromBody] NS_H20 h20)
        {
            if (h20 == null)
            {
                return BadRequest("h20 is null.");
            }

            _dataRepository.Add(h20);
            return CreatedAtRoute("Get", new { Id = h20.NS_H20_ID }, h20);
        }

        // PUT api/{version:apiVersion}/H20/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NS_H20 value)
        {

        }

        // DELETE api/<H20_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
