using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class JTFA_Invoice_Context : DbContext
    {
        public JTFA_Invoice_Context(DbContextOptions<JTFA_Invoice_Context> options) : base(options)
        {
        }

        public DbSet<JTFA_Invoice> JTFA_Invoice { get; set; }

        
    }
}
