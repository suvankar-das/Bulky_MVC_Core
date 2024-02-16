using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.RepositoryInterface
{
    // T will be generic model like Category etc
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetItem(Expression<Func<T,bool>> filter);

        void AddItem(T item);
        void RemoveItem(T item);
        void RemoveRange(IEnumerable<T> items);
    }
}
