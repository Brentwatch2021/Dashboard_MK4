using Dashboard_MK4.Models.V3_Models;
using Dashboard_MK4.Models.V3_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V3_DataManager
{
    public class JTFA_Invoice_Manager : IJTFA_Invoice_Data_Repository<JTFA_Invoice>
    {
        public readonly JTFA_Invoice_Context _jTFA_Invoice_Context;

        public JTFA_Invoice_Manager(JTFA_Invoice_Context jTFA_Invoice_Context)
        {
            this._jTFA_Invoice_Context = jTFA_Invoice_Context;
        }

        public void Add(JTFA_Invoice entity)
        {
            this._jTFA_Invoice_Context.JTFA_Invoice.Add(entity);
            this._jTFA_Invoice_Context.SaveChanges();
        }

        public void Delete(JTFA_Invoice entity)
        {
            this._jTFA_Invoice_Context.JTFA_Invoice.Remove(entity);
            this._jTFA_Invoice_Context.SaveChanges();
        }

        public JTFA_Invoice Get(Guid id)
        {
             return this._jTFA_Invoice_Context.JTFA_Invoice.Where(jtfa_Invoice => jtfa_Invoice.JTFA_Invoice_ID == id).FirstOrDefault();
        }

        public IEnumerable<JTFA_Invoice> GetAll()
        {
            return this._jTFA_Invoice_Context.JTFA_Invoice;
        }

        public void Update(JTFA_Invoice dbEntity, JTFA_Invoice entity)
        {
            dbEntity.INV_Number = entity.INV_Number;
            dbEntity.Email_Recipients = entity.Email_Recipients;
            dbEntity.JobCardID = entity.JobCardID;
            this._jTFA_Invoice_Context.SaveChanges();
        }
    }
}
