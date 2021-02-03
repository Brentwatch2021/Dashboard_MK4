using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.N_S_Models.NS_Temperature
{
    public class NS_Temperature_Context : DbContext
    {
        public NS_Temperature_Context(DbContextOptions<NS_Temperature_Context> options) : base(options)
        { }


        public DbSet<NS_Temperature> Temp_Datasets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
    
