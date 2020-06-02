using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.BookStoreTut
{
    public class Book_Review_Context : DbContext
    {
        public Book_Review_Context(DbContextOptions<Book_Review_Context> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
