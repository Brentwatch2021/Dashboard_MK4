using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_DataManager
{
    public class Job_Card_Manager : IJobCardDataRepository<Job_Card>
    {
        readonly Job_Card_Context _jobCardContext;


        public Job_Card_Manager(Job_Card_Context job_Card_Context)
        {
            _jobCardContext = job_Card_Context;
        }


        public void Add(Job_Card entity)
        {
            _jobCardContext.JobCards.Add(entity);
            _jobCardContext.SaveChanges();
        }

        public void Delete(Job_Card entity)
        {
            _jobCardContext.JobCards.Remove(entity);
            _jobCardContext.SaveChanges();
        }

        public Job_Card Get(Guid id)
        {
            return _jobCardContext.JobCards.FirstOrDefault(e => e.JobCardID == id);
        }

        public IEnumerable<Job_Card> GetAll()
        {
            return _jobCardContext.JobCards.ToList();
        }

        public void Update(Job_Card dbEntity, Job_Card entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Invoice = entity.Invoice;
            //dbEntity.Task_Descripts = entity.Task_Descripts;
            dbEntity.Email = entity.Email;
            dbEntity.Date = entity.Date;
            dbEntity.Phone = entity.Phone;
            dbEntity.Notes = entity.Notes;
            dbEntity.REG = entity.REG;
            dbEntity.Total = entity.Total;
            dbEntity.VIN = entity.VIN;
            dbEntity.Car = entity.Car;
            _jobCardContext.SaveChanges();
        }
    }
}
