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

        
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await DBEntity.ToListAsync();
            return result;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var result = await DBEntity.FindAsync(id);
            return result;
        }



        public IEnumerable<TEntity> GetAll()
        {
            var result = DBEntity.ToList();
            return result;
        }

        public TEntity Get(int id)
        {
            var result = DBEntity.Find(id);
            return result;
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
            if (item != null)
                DBEntity.Remove(item);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();

        }
    }
}
