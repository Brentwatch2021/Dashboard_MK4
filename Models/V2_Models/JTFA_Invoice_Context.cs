using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class JTFA_Invoice_Context : DbContext
    {
        public JTFA_Invoice_Context(DbContextOptions<JTFA_Invoice_Context> options) : base(options)
        {
        }

        protected JTFA_Invoice_Context()
        {
        }

        public DbSet<JTFA_Invoice> Jtfa_Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JTFA_Invoice>().HasData(new JTFA_Invoice()
            {
                JTFA_INVOICE_ID = new Guid("00000000-0000-0000-0000-000000000004")
            }) ;
        }

    }
}
