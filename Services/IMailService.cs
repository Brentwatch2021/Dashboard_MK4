using Dashboard_MK4.Models.V3_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail_Request mail_Request, JobCardV3 jobCard);
    }
}
