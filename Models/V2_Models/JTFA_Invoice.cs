using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_Models
{
    public class JTFA_Invoice
    {
        public Guid JTFA_INVOICE_ID { get; set; }

        public string InvoiceNo { get; set; }

        public List<TaskDescription> JTFA_Task_Description  { get; set; }

        public string Grand_Total { get; set; }

        public string Business_Banking_Details { get; set; }


    }
}
