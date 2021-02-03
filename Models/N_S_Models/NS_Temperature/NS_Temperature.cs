using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.N_S_Models.NS_Temperature
{
    public class NS_Temperature
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NS_Temperature_ID { get; set; }

        public int Temperature { get; set; }

        public DateTime TimeStamp { get; set; }


    }
}
