using Dashboard_MK4.Models.V2_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class JobCardV3
    {
        [Column("JobCardID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid JobCardID { get; set; }

        [Column("JobCardName")]
        [StringLength(100)]
        [Required]
        public string JobCardName { get; set; }

        public ICollection<TaskDescriptionV3> TaskDescriptions { get; set; }

        // IGNORE the attributes below this is for the Mobile API
        public Vehicle_Display_ID VehicleDisplay { get; set; }

        public Client_Display_ID ClientDisplay { get; set; }

        public VehicleV3 VehicleV3 { get; set; }

        public Vehicle Vehicle { get; set; }

        public JTFA_Client JTFA_Client { get; set; }



    }
}
