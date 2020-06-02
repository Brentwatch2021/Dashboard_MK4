using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_DataManager
{
    public class JTFA_Client_Manager : IJTFA_Client_Data_Repository<JTFA_Client>
    {
        readonly JTFA_Client_Context _jTFA_Client_Context;

        public JTFA_Client_Manager(JTFA_Client_Context jTFA_Client_Context)
        {
            _jTFA_Client_Context = jTFA_Client_Context;
        }


        public void Add(JTFA_Client entity)
        {
            _jTFA_Client_Context.JTFA_Clients.Add(entity);
            _jTFA_Client_Context.SaveChanges();
        }

        public void Delete(JTFA_Client entity)
        {
            _jTFA_Client_Context.JTFA_Clients.Remove(entity);
            _jTFA_Client_Context.SaveChanges();
        }

        public JTFA_Client Get(Guid id)
        {
            return _jTFA_Client_Context.JTFA_Clients.FirstOrDefault(e => e.JTFA_CLIENT_ID == id);
        }

        public IEnumerable<JTFA_Client> GetAll()
        {
            return _jTFA_Client_Context.JTFA_Clients.ToList();
        }

        public void Update(JTFA_Client dbEntity, JTFA_Client entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.Email = entity.Email;
            dbEntity.Notifications_Permission_Levels_Allowed = entity.Notifications_Permission_Levels_Allowed;
            _jTFA_Client_Context.SaveChanges();
            
        }
    }
}
