using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class JTFA_Client_Context : DbContext
    {
        public JTFA_Client_Context(DbContextOptions<JTFA_Client_Context> options) : base(options)
        {
        }

        public DbSet<JTFA_Client> JTFA_Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JTFA_Client>().HasData(new JTFA_Client
            {
                JTFA_CLIENT_ID = new Guid("00000000-0000-0000-0000-000000000003"),
                Name = "----------Daffy Duck------------",
                Email = "----------Daffyduckrules@WarnerBros.com ---------",
                Notifications_Permission_Levels_Allowed = "Yes",
                PhoneNumber = "-----0000----"
            }); 
        }
    }
}
