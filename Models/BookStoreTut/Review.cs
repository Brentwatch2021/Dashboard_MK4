using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.BookStoreTut
{
    public class Review
    {
        public int ID { get; set; }
        // Foreign Key Below
        public int BookID { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }
    }
}
