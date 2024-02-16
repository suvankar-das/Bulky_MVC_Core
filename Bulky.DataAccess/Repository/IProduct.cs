using Bulky.DataAccess.RepositoryInterface;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public interface IProduct:IRepository<Product>
    {
        void Update(Product category);
    }
}
