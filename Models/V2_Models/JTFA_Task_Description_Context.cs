using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class JTFA_Task_Description_Context : DbContext
    {
        public JTFA_Task_Description_Context(DbContextOptions<JTFA_Task_Description_Context> options) : base(options)
        {
        }

        public DbSet<TaskDescription> TaskDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskDescription>().HasData(new TaskDescription
            {
                Task_Description_ID = new Guid("00000000-0000-0000-0000-000000000005"),
                Description = "Remove and fit clutch kit",
                Labour = " 2 hours",
                Parts = "R2200",
                Total = "R2550"
            });
        }
    }
}
