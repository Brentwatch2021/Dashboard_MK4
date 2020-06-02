using Dashboard_MK4.Models.V2_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class JobCard_TaskDescriptions_Context : DbContext
    {
        public JobCard_TaskDescriptions_Context(DbContextOptions<JobCard_TaskDescriptions_Context> options) : base(options)
        {
        }

        public DbSet<JobCardV3> JobCardsV3 { get; set; }
        public DbSet<TaskDescriptionV3> TaskDescriptions { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<JobCard_Name_TaskDesc_ID> TaskDescripsDisplayIds { get; set; }
        //public Vehicle_Display_ID VehicleDisplayID { get; set; }
        
        //public Client_Display_ID ClientDisplayID { get; set; }

        public DbSet<JTFA_Client> JTFA_Clients { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobCardV3>().HasData(new JobCardV3
            {
                JobCardID = new Guid("00000000-0000-0000-0000-000000000012"),
                JobCardName = "Clutch Replacement"
            });

        }
    }
}
