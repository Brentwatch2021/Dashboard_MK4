using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class JTFA_Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid JTFA_Invoice_ID { get; set; }

        public int INV_Number { get; set; }

        public JobCardV3 JobcardV3 { get; set; }

        public string Email_Recipients { get; set; }

    }
}
