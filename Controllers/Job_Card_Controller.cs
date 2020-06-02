using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using EmailService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Controllers
{
    
    [Route("api/jobcard")]
    [ApiController]
    public class Job_Card_Controller : ControllerBase
    {
        
        //private readonly IEmailSender _emailSender;
        private readonly IJobCardDataRepository<Job_Card> _dataRepository;
        public Job_Card_Controller(IJobCardDataRepository<Job_Card> dataRepository)
        {
            _dataRepository = dataRepository;
            //_emailSender = emailSender;
        }

        // GET: api/jobcard
        [HttpGet]
        public IActionResult GetJobCards()
        {
            //var message = new Message(new string[] { "beckerbrent04@gmail.com" }, "Test email", "This is the content from our email.");
            //_emailSender.SendEmail(message);

            // 
            IEnumerable<Job_Card> jobcards = _dataRepository.GetAll();
            return Ok(jobcards);
        }

        // GET: api/jobCard/5
        [HttpGet("{id}", Name = "GetJobCard")]
        public IActionResult GetJobCard(Guid id)
        {
            Job_Card jobCard = _dataRepository.Get(id);
            if (jobCard == null)
            {
                return NotFound("The JobCard record couldn't be found.");
            }
            return Ok(jobCard);
        }

        // POST: api/jobcard
        [HttpPost]
        public IActionResult Post([FromBody] Job_Card jobcard)
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

        // PUT: api/jobcard/00000000-0000-0000-0000-000000000001
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Job_Card jobCard)
        {
            if (jobCard == null)
            {
                return BadRequest("JobCard is Null");
            }

            Job_Card jobCardToUpdate = _dataRepository.Get(id);
            if (jobCardToUpdate == null)
            {
                return NotFound("The Jobcard record couldn't be found.");
            }

            _dataRepository.Update(jobCardToUpdate, jobCard);
            return NoContent();
        }

        // DELETE: api/jobcard
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Job_Card jobcard = _dataRepository.Get(id);
            if (jobcard == null)
            {
                return NotFound("The JobCard record couldn't be found.");
            }

            _dataRepository.Delete(jobcard);
            return NoContent();
        }


    }
}
