using Enoca.Entity.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using OpenAI.DataAccess.Concretes;
using System.Linq;
using System.Linq.Expressions;

namespace Enoca.Entity.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly  OAContext _db;
        internal DbSet<T> dbSet;

        public Repository(OAContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return dbSet.ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
