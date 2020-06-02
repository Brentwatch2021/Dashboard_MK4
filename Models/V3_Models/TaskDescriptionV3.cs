using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class TaskDescriptionV3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("Task_Description_ID")]
        public Guid Task_Description_ID { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("LabourCost")]
        public string LabourCost { get; set; }

        [Column("PartsPrice")]
        public string PartsPrice { get; set; }

        [Column("TotalTaskCost")]
        public string TotalTaskCost { get; set; }

        public JobCardV3 JobCardV3 { get; set; }
        public Guid JobCardIDForRef { get; set; }
        
    }
}
