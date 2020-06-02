using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard_MK4.Models.V2_Models
{
    public class TaskDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Task_Description_ID { get; set; } 

        public string Description { get; set; }

        public string Labour { get; set; }

        public string Parts { get; set; }

        public string Total { get; set; }

    }
}