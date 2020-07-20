using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Controllers
{
    [Route("api/{version:apiVersion}/JTFA_invoice")]
    [ApiController]
    public class JTFA_Invoice_Controller : ControllerBase
    {
        private readonly IJTFA_Invoice_Data_Repository<JTFA_Invoice> _dataRepository;

        public JTFA_Invoice_Controller(IJTFA_Invoice_Data_Repository<JTFA_Invoice> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        #region API Methods

        [HttpGet("{id}", Name = "GetJTFA_Invoice")]
        public IActionResult Get_JTFA_Invoice(Guid id) 
        {
            JTFA_Invoice jtfa_Invoice = null;
            if (id != null || id == Guid.Empty)
            {
                jtfa_Invoice = this._dataRepository.Get(id);
                if (jtfa_Invoice == null)
                {
                    return NotFound("The Invoice record couldn't be found.");
                }
            }
            return Ok(jtfa_Invoice);
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            IEnumerable<JTFA_Invoice> invoices = this._dataRepository.GetAll();
            return Ok(invoices);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JTFA_Invoice jtfa_Invoice, ApiVersion apiVersion)
        {
            if (jtfa_Invoice == null)
            {
                return BadRequest("Invoice is null.");
            }

            this._dataRepository.Add(jtfa_Invoice);
            CreatedAtRouteResult response = null;
            try
            {
                // First param describes the name of the get method to get the item after its created
                response = CreatedAtRoute("GetJTFA_Invoice", new { id = jtfa_Invoice.JTFA_Invoice_ID, version = apiVersion.ToString() }, jtfa_Invoice);
            }
            catch (Exception ex)
            {
                
            }
            
            return response;

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            JTFA_Invoice jtfa_Invoice = this._dataRepository.Get(id);
            if (jtfa_Invoice == null)
            {
                return NotFound("The Invoice record couldn't be found.");
            }

            this._dataRepository.Delete(jtfa_Invoice);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] JTFA_Invoice jtfa_Invoice)
        {
            if (jtfa_Invoice == null)
            {
                return BadRequest("Invoice is Null");
            }

            JTFA_Invoice jTFA_Invoice_ToUpdate = _dataRepository.Get(id);
            if (jTFA_Invoice_ToUpdate == null)
            {
                return NotFound("The invoice record couldn't be found.");
            }

            this._dataRepository.Update(jTFA_Invoice_ToUpdate, jtfa_Invoice);
            return NoContent();
        }


        #endregion API Methods
    }
}
