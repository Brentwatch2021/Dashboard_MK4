using Dashboard_MK4.Models.N_S_Models.NS_Temperature;
using Dashboard_MK4.Models.NS_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.NS_DataManager
{
    public class NS_Temperature_Data_Manager : INS_Temperature_Repository<NS_Temperature>
    {
        public NS_Temperature_Context ns_Temperature_Context;

        public void Add(NS_Temperature entity)
        {
            ns_Temperature_Context.Attach(entity);
            ns_Temperature_Context.SaveChanges();
        }

        public void Delete(NS_Temperature entity)
        {
            ns_Temperature_Context.Temp_Datasets.Remove(entity);
            ns_Temperature_Context.SaveChanges();
        }

        public NS_Temperature Get(Guid id)
        {
            NS_Temperature temp = new NS_Temperature();
            temp = ns_Temperature_Context.Temp_Datasets.Where(p => p.NS_Temperature_ID == id).FirstOrDefault();
            return temp;
        }

        public IEnumerable<NS_Temperature> GetAll()
        {
            List<NS_Temperature> temps = ns_Temperature_Context.Temp_Datasets.ToList();
            return temps;
        }

        public void Update(NS_Temperature dbEntity, NS_Temperature entity)
        {
            dbEntity.Temperature = entity.Temperature;
            dbEntity.TimeStamp = entity.TimeStamp;
            ns_Temperature_Context.SaveChanges();
        }
    }
}
