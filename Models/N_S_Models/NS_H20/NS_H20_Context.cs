using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.N_S_Models.NS_H20
{
    public class NS_H20_Context : DbContext
    {
        public NS_H20_Context(DbContextOptions<NS_H20_Context> options) : base(options)
        { }

        public DbSet<NS_H20> H20_Datasets { get; set; }


    }
}
