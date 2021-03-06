using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> Query();

      

        Task Create(TEntity entity);
        void Update(TEntity entityToUpdate);
    }

   


}
