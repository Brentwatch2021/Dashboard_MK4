using Dashboard_MK4.Models.N_S_Models.NS_H20;
using Dashboard_MK4.Models.NS_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.NS_DataManager
{
    public class NS_H20_Data_Manager : INS_H20_Repository<NS_H20>
    {
        public NS_H20_Context ns_H20_Context;

        public NS_H20_Data_Manager(NS_H20_Context ns_H20_Context)
        {
            this.ns_H20_Context = ns_H20_Context;
        }

        public void Add(NS_H20 entity)
        {
            ns_H20_Context.Attach(entity);
            ns_H20_Context.SaveChanges();
        }

        public void Delete(NS_H20 entity)
        {
            ns_H20_Context.H20_Datasets.Remove(entity);
            ns_H20_Context.SaveChanges();
        }

        public NS_H20 Get(Guid id)
        {
            NS_H20 h20 = new NS_H20();
            h20 = ns_H20_Context.H20_Datasets.Where(p => p.NS_H20_ID == id).FirstOrDefault();
            return h20;
        }

        public IEnumerable<NS_H20> GetAll()
        {
            List<NS_H20> h20s = ns_H20_Context.H20_Datasets.ToList();
            return h20s;
        }

        public void Update(NS_H20 dbEntity, NS_H20 entity)
        {
            dbEntity.Litres_In_Stock = entity.Litres_In_Stock;
            dbEntity.TimeStamp = entity.TimeStamp;
            ns_H20_Context.SaveChanges();
        }
    }
}
