using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_DataManager
{
    public class TaskDescription_Data_Manager : ITaskDescription_Data_Repository<TaskDescription>
    {
        readonly JTFA_Task_Description_Context _jTFA_Task_Description_Context;

        public TaskDescription_Data_Manager(JTFA_Task_Description_Context jTFA_Task_Description_Context)
        {
            _jTFA_Task_Description_Context = jTFA_Task_Description_Context;
        }

        public void Add(TaskDescription entity)
        {
            _jTFA_Task_Description_Context.TaskDescriptions.Add(entity);
            _jTFA_Task_Description_Context.SaveChanges();
        }

        public void Delete(TaskDescription entity)
        {
            _jTFA_Task_Description_Context.Remove(entity);
            _jTFA_Task_Description_Context.SaveChanges();
        }

        public TaskDescription Get(Guid id)
        {
            return _jTFA_Task_Description_Context.TaskDescriptions.FirstOrDefault(e => e.Task_Description_ID == id);
        }

        public IEnumerable<TaskDescription> GetAll()
        {
            return _jTFA_Task_Description_Context.TaskDescriptions.ToList();
        }

        public void Update(TaskDescription dbEntity, TaskDescription entity)
        {
            dbEntity.Description = entity.Description;
            dbEntity.Labour = entity.Labour;
            dbEntity.Parts = entity.Parts;
            dbEntity.Total = entity.Total;

            _jTFA_Task_Description_Context.SaveChanges();
        }
    }
}
