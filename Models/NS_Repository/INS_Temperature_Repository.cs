using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.NS_Repository
{
    public interface INS_Temperature_Repository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
