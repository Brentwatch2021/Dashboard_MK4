using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Controllers
{
    [Route("api/jobcardV3")]
    [ApiController]
    public class JobCardV3_Controller : ControllerBase
    {
        private readonly IJobCardV3DataRepository<JobCardV3> _dataRepository;

        public JobCardV3_Controller(IJobCardV3DataRepository<JobCardV3> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/jobCard/5
        [HttpGet("{id}", Name = "GetJobCardV3")]
        public IActionResult GetJobCardV3(Guid id)
        {
            JobCardV3 jobCard = _dataRepository.Get(id);
            if (jobCard == null)
            {
                return NotFound("The JobCard record couldn't be found.");
            }
            return Ok(jobCard);
        }

        // GET: api/jobcardV3
        [HttpGet]
        public IActionResult GetJobCards()
        {
            // 
            IEnumerable<JobCardV3> jobcards = _dataRepository.GetAll();
            return Ok(jobcards);
        }

        // POST: api/jobcardV3
        [HttpPost]
        public IActionResult Post([FromBody] JobCardV3 jobcard)
        {
            if (jobcard == null)
            {
                return BadRequest("JobCard is null.");
            }

            _dataRepository.Add(jobcard);
            return CreatedAtRoute(
                  "Get",
                  new { Id = jobcard.JobCardID },
                  jobcard);
        }

        // DELETE: api/jobcard
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            JobCardV3 jobcard = _dataRepository.Get(id);
            if (jobcard == null)
            {
                return NotFound("The JobCard record couldn't be found.");
            }

            _dataRepository.Delete(jobcard);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] JobCardV3 jobCard)
        {
            if (jobCard == null)
            {
                return BadRequest("JobCard is Null");
            }

            JobCardV3 jobCardToUpdate = _dataRepository.Get(id);
            if (jobCardToUpdate == null)
            {
                return NotFound("The Jobcard record couldn't be found.");
            }

            _dataRepository.Update(jobCardToUpdate, jobCard);
            return NoContent();
        }

    }
}
