using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class Job_Card_Context : DbContext
    {
        public List<TaskDescription> dummytaskdescriptions = new List<TaskDescription>();
        public Job_Card_Context(DbContextOptions<Job_Card_Context> options) : base(options)
        {
            
        }

        public DbSet<Job_Card> JobCards { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            TaskDescription dummytaskDescription = new TaskDescription();
            dummytaskDescription.Task_Description_ID = new Guid("00000000-0000-0000-0000-000000000006");
            dummytaskDescription.Parts = "550";
            dummytaskDescription.Labour = "550";
            dummytaskDescription.Description = "Remove and fit coil";
            dummytaskDescription.Total = "1100";
            dummytaskdescriptions.Add(dummytaskDescription);


            modelBuilder.Entity<Job_Card>().HasData(new Job_Card
            {
                JobCardID = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "MICar Centre",
                Email = "blah@micarcentre.com",
                Car = "Toyota Hilux",
                Date = DateTime.UtcNow,
                Invoice = "SC 1000",
                //Task_Descripts = dummytaskdescriptions,
                Mileage = "10000000000",
                Phone = "021 558 4589",
                REG = "CY",
                Total = "R999999999999",
                VIN = "DRUK",
                Notes = "Awe"
            })  ;
        }
    }
}
