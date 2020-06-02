using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class Vehicle_Context : DbContext
    {
        public Vehicle_Context(DbContextOptions<Vehicle_Context> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
            Vehicle_ID = new Guid("00000000-0000-0000-0000-000000000002"),
            Make = "Ford",
            REG = "Eleanor",
            }); 
        }
    }
}
