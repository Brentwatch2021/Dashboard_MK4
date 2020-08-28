using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard_MK4.Models.V3_Models;
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
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        //[HttpGet]
        //public IActionResult GetMail ()
        //{
        //    string test = "test";
        //    return Ok(test);
        //}


        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] Mail_Request request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
