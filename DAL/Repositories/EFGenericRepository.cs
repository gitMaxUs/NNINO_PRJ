using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        EFContext _context;
        DbSet<TEntity> DBEntity;

        public EFGenericRepository(EFContext context)
        {
            _context = context;
            DBEntity = context.Set<TEntity>();
        }



        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var result = await DBEntity.ToListAsync();
            return result;
            // return  DBEntity.ToList();
        }

        public async Task<TEntity> Get(int id)
        {
            var result = await DBEntity.FindAsync(id);
            return result;
            //  return DBEntity.Find(id);
        }

        public void Create(TEntity item)
        {
            DBEntity.Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var item = DBEntity.Find(id.Value);
            DBEntity.Remove(item);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            var result = _context.Set<TEntity>().Where(predicate).ToList();

            return result;
        }
    }
}
