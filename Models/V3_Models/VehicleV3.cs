using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class VehicleV3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Vehicle_ID { get; set; }

        public string Make { get; set; }

        public string VIN { get; set; }

        public string REG { get; set; }

        public string Mileage { get; set; }

        public string Engine_Number { get; set; }

        public string Year { get; set; }

        public string CC { get; set; }
    }
}
