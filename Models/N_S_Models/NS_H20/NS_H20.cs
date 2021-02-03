using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.N_S_Models.NS_H20
{
    public class NS_H20
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NS_H20_ID { get; set; }

        public int Litres_In_Stock { get; set; }

        public DateTime TimeStamp { get; set; }

        //public Chem_Parameters Water_Chemical_Make_Up { get; set; }
    }
}
