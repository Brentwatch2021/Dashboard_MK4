using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class Mail_Request_Context : DbContext
    {
        public Mail_Request_Context(DbContextOptions<Mail_Request_Context> options) : base(options)
        {
        }

        public DbSet<Mail_Request> MailRequests { get; set; }
    }
}
