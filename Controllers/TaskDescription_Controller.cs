using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Controllers
{
    [Route("api/taskdescription")]
    [ApiController]
    public class TaskDescription_Controller : ControllerBase
    {
        private readonly ITaskDescription_Data_Repository<TaskDescription> _dataRepository;

        public TaskDescription_Controller(ITaskDescription_Data_Repository<TaskDescription> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetTaskDescriptions()
        {
            IEnumerable<TaskDescription> taskDescriptions = _dataRepository.GetAll();
            return Ok(taskDescriptions);
        }

        [HttpGet("{id}", Name = "GetTaskDescription")]
        public IActionResult GetJobCard(Guid id)
        {
            TaskDescription taskDescription = _dataRepository.Get(id);
            if (taskDescription == null)
            {
                return NotFound("The TaskDescription record couldn't be found.");
            }
            return Ok(taskDescription);
        }


        [HttpPost]
        public IActionResult Post([FromBody] TaskDescription taskDescription)
        {
            if (taskDescription == null)
            {
                return BadRequest("Task Description is null.");
            }

            _dataRepository.Add(taskDescription);
            return CreatedAtRoute(
                  "Get",
                  new { Id = taskDescription.Task_Description_ID },
                  taskDescription);
        }


         
        public IActionResult Put(Guid id, [FromBody] TaskDescription taskDescription)
        {
            if (taskDescription == null)
            {
                return BadRequest("Task Description is Null");
            }

            TaskDescription taskDescription_To_Update = _dataRepository.Get(id);
            if (taskDescription_To_Update == null)
            {
                return NotFound("The TaskDescription_To_Update record couldn't be found.");
            }

            _dataRepository.Update(taskDescription_To_Update, taskDescription);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            TaskDescription taskDescription = _dataRepository.Get(id);
            if (taskDescription == null)
            {
                return NotFound("The taskDescription record couldn't be found.");
            }

            _dataRepository.Delete(taskDescription);
            return NoContent();
        }

    }
}
