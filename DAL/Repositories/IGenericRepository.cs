using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Create(TEntity item);

        void Update(TEntity item);

        void Delete(int? id);

        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
    }
}
