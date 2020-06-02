using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class Job_Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid JobCardID { get; set; }
        public string Name { get; set; }

        public string VIN { set; get; }

        public string Email { set; get; }

        public string Car { get; set; }

        public DateTime Date { get; set; }

        public string Invoice { get; set; }

        public string REG { get; set; }

        public string Phone { get; set; }

        public string Mileage { get; set; }

        //public List<TaskDescription> Task_Descripts { get; set; }

        public string Total { get; set; }

        public string Notes { get; set; }
    }
}
