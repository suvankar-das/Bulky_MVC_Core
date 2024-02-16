using Bulky.DataAccess.Data;
using Bulky.DataAccess.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            // _dbSet means all the data
            _dbSet = _db.Set<T>();
        }
        public void AddItem(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetItem(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public void RemoveItem(T item)
        {
            _dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }
    }
}
