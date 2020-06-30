using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_DataManager
{
    public class JobCardV3_Manager : IJobCardV3DataRepository<JobCardV3>
    {
        public readonly JobCard_TaskDescriptions_Context _jobCard_TaskDescriptions_Context;

        public JobCardV3_Manager(JobCard_TaskDescriptions_Context jobCard_TaskDescriptions_Context)
        {
            _jobCard_TaskDescriptions_Context = jobCard_TaskDescriptions_Context;
        }

        public void Add(JobCardV3 entity)
        {
            // Try 1 This was where foreign key was declared on 
            // collection of task description in jobCard model
            // All taskdescriptionIDS get duplicated and blows up
            //_jobCard_TaskDescriptions_Context.Add(entity);
            //_jobCard_TaskDescriptions_Context.SaveChanges();

            // Try 2
            // This creates all however only one description allowed
            // and all ids are the same jcID, TDID, 
            //_jobCard_TaskDescriptions_Context.TaskDescriptions.AddRange(entity.TaskDescriptions);
            //_jobCard_TaskDescriptions_Context.JobCards.Add(entity);
            //entity.TaskDescriptions[0].JobCardID = entity.JobCardID;
            //_jobCard_TaskDescriptions_Context.SaveChanges();

            // Try 3
            // Creates two jobcards as expected with two unique IDS
            //JobCardV3 jobCard = new JobCardV3() { JobCardName = "jobCard1" };
            //JobCardV3 jobCard1 = new JobCardV3() { JobCardName = "jobCard2" };
            //List<JobCardV3> jobcards = new List<JobCardV3>();
            //jobcards.Add(jobCard);
            //jobcards.Add(jobCard1);
            //_jobCard_TaskDescriptions_Context.JobCards.AddRange(jobcards);
            //_jobCard_TaskDescriptions_Context.SaveChanges();

            // Try 4
            // Try number 4 results in this error however both descriptions create unique ids unlike above however unable to 
            // save to database results in INSERT sql error similar to migration issue problem is in relation on jobcard model
            //TaskDescriptionV3 taskDescription = new TaskDescriptionV3() { Description="td1"};
            //TaskDescriptionV3 taskDescription1 = new TaskDescriptionV3() { Description = "td2" };
            //List<TaskDescriptionV3> taskDescrips = new List<TaskDescriptionV3>();
            //taskDescrips.Add(taskDescription);
            //taskDescrips.Add(taskDescription1);
            //_jobCard_TaskDescriptions_Context.TaskDescriptions.AddRange(taskDescrips);
            //_jobCard_TaskDescriptions_Context.SaveChanges();

            // Problem lies in model structure research the relationship bindings

            // Try 5 with changes made to the JobCardV3 model by removing the foriegn key on collection
            // Works however does not get the created id from jobcard in the task descriptions 
            
            // Try 6 When trying to link an already created entity it throws an error
            //_jobCard_TaskDescriptions_Context.Add(entity);
            
            
            _jobCard_TaskDescriptions_Context.Attach(entity);
            _jobCard_TaskDescriptions_Context.SaveChanges();

            

        }

        public void Delete(JobCardV3 entity)
        {
            _jobCard_TaskDescriptions_Context.JobCardsV3.Remove(entity);
            _jobCard_TaskDescriptions_Context.SaveChanges();
        }

        public JobCardV3 Get(Guid id)
        {
            JobCardV3 jobcardV3 = new JobCardV3();
            jobcardV3 = _jobCard_TaskDescriptions_Context.JobCardsV3.Where(p => p.JobCardID == id).Include(j => j.JTFA_Client).Include(j => j.Vehicle).Include(j => j.TaskDescriptions).FirstOrDefault();
            return jobcardV3;
        }

        public IEnumerable<JobCardV3> GetAll()
        {
          
            List<JobCardV3> jobcards = _jobCard_TaskDescriptions_Context.JobCardsV3.ToList();
            //jobcards.Add(jobcardTest);

            return jobcards;
            //return _jobCard_TaskDescriptions_Context.JobCardsV3.Include(jc => jc.Vehicle).Include(jcc => jcc.JTFA_Client).Include(jct => jct.TaskDescriptions).ToList(); ;
        }

        public void Update(JobCardV3 dbEntity, JobCardV3 entity)
        {
            dbEntity.JobCardName = entity.JobCardName;
            if(dbEntity?.Vehicle?.Vehicle_ID != entity?.Vehicle?.Vehicle_ID)
            {
                dbEntity.Vehicle = entity.Vehicle;
            }
            if (dbEntity?.JTFA_Client.JTFA_CLIENT_ID != entity?.JTFA_Client?.JTFA_CLIENT_ID)
            {
                dbEntity.JTFA_Client = entity.JTFA_Client;
            }
            UpdateTaskDecriptions(dbEntity, entity);
            _jobCard_TaskDescriptions_Context.SaveChanges();
        }

        private void UpdateTaskDecriptions(JobCardV3 dbEntity, JobCardV3 entity)
        {
            foreach (TaskDescriptionV3 td3 in entity.TaskDescriptions)
            {
                if (td3.Task_Description_ID == Guid.Empty)
                {
                    // addition
                    dbEntity.TaskDescriptions.Add(td3);
                }
                else
                {
                    // Update
                    TaskDescriptionV3 taskDescriptionUpdate = dbEntity.TaskDescriptions.
                        Where(td => td.Task_Description_ID == td3.Task_Description_ID).FirstOrDefault();

                    if (taskDescriptionUpdate.Description != td3.Description)
                    {
                        taskDescriptionUpdate.Description = td3.Description;
                    }

                    if (taskDescriptionUpdate.LabourCost != td3.LabourCost)
                    {
                        taskDescriptionUpdate.LabourCost = td3.LabourCost;
                    }

                    if (taskDescriptionUpdate.PartsPrice != td3.PartsPrice)
                    {
                        taskDescriptionUpdate.PartsPrice = td3.PartsPrice;
                    }

                    if (taskDescriptionUpdate.TotalTaskCost != td3.TotalTaskCost)
                    {
                        taskDescriptionUpdate.TotalTaskCost = td3.TotalTaskCost;
                    }

                }
            }

            // Removals implmentation
            if (entity.TaskDescriptions.Count < dbEntity.TaskDescriptions.Count)
            {
                List<TaskDescriptionV3> tdsToremove = new List<TaskDescriptionV3>();

                foreach (TaskDescriptionV3 td3R in dbEntity.TaskDescriptions)
                {
                    TaskDescriptionV3 taskDescriptionRemoval = entity.TaskDescriptions.
                        Where(td => td.Task_Description_ID == td3R.Task_Description_ID).FirstOrDefault();

                    if (taskDescriptionRemoval == null)
                    {
                        tdsToremove.Add(td3R);
                    }

                }

                for (var i = 0; i < tdsToremove.Count; i++)
                {
                    dbEntity.TaskDescriptions.Remove(tdsToremove[i]);
                }

            }
        }
    }
}
