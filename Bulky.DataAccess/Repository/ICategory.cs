using Bulky.DataAccess.RepositoryInterface;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public interface ICategory:IRepository<Category>
    {
        void Update(Category category);
    }
}
