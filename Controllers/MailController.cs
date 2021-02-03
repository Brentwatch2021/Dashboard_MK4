using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_Repository;
using Dashboard_MK4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MK4.Controllers
{
    [Route("api/{version:apiVersion}/mail")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;

        private readonly IJobCardV3DataRepository<JobCardV3> _dataRepository;
        public MailController(IMailService mailService, IJobCardV3DataRepository<JobCardV3> dataRepository)
        {
            this.mailService = mailService;
            this._dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetMail ()
        {
            string test = "test";
            return Ok(test);
        }


        [HttpPost()]
        public async Task<IActionResult> SendMail([FromBody] Mail_Request request)
        {
            try
            {
                JobCardV3 jobCard = _dataRepository.Get(new Guid(request.JobCardID));
                await mailService.SendEmailAsync(request,jobCard);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
