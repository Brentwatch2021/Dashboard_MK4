using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MK4.Controllers
{
    [Route("api/JTFA_Client")]
    [ApiController]
    public class JTFA_Client_Controller : ControllerBase
    {
        private readonly IJTFA_Client_Data_Repository<JTFA_Client> _dataRepository;
        public JTFA_Client_Controller(IJTFA_Client_Data_Repository<JTFA_Client> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/JTFA_Client
        [HttpGet]
        public IActionResult GetJobCards()
        {
            IEnumerable<JTFA_Client> jTFA_Clients = _dataRepository.GetAll();
            return Ok(jTFA_Clients);
        }

        // GET: api/JTFA_Client/5
        [HttpGet("{id}", Name = "Get_JTFA_Clients")]
        public IActionResult Get_JTFA_Clients(Guid id)
        {
            JTFA_Client jTFA_Client = _dataRepository.Get(id);
            if (jTFA_Client == null)
            {
                return NotFound("The jTFA_Client record couldn't be found.");
            }
            return Ok(jTFA_Client);
        }

        // POST: api/JTFA_Client
        [HttpPost]
        public IActionResult Post([FromBody] JTFA_Client jTFA_Client)
        {
            if (jTFA_Client == null)
            {
                return BadRequest("JTFA_Client is null.");
            }

            _dataRepository.Add(jTFA_Client);
            return CreatedAtRoute(
                  "Get",
                  new { Id = jTFA_Client.JTFA_CLIENT_ID },
                  jTFA_Client);
        }

        // PUT: api/JTFA_Client/00000000-0000-0000-0000-000000000001
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] JTFA_Client jTFA_Client)
        {
            if (jTFA_Client == null)
            {
                return BadRequest("JTFA_Client is Null");
            }

            JTFA_Client jTFA_Client_To_Update = _dataRepository.Get(id);
            if (jTFA_Client_To_Update == null)
            {
                return NotFound("The JTFA_Client_To_Update record couldn't be found.");
            }

            _dataRepository.Update(jTFA_Client_To_Update, jTFA_Client);
            return NoContent();
        }

        // DELETE: api/jTFA_Client
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            JTFA_Client jTFA_Client = _dataRepository.Get(id);
            if (jTFA_Client == null)
            {
                return NotFound("The JTFA_Client record couldn't be found.");
            }

            _dataRepository.Delete(jTFA_Client);
            return NoContent();
        }

    }
}
