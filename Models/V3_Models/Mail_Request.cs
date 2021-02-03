using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_Models
{
    public class Mail_Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Mail_Request_ID { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string JobCardID { get; set; }
        public string Body { get; set; }
        //public List<IFormFile> Attachments { get; set; }
        
    }
}
