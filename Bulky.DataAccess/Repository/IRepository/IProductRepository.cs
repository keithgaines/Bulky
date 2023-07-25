using Bulky.Models;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
        Product Get(int id);
        void Remove(int id);

        IEnumerable<Product> GetAllProductsIncludingCategories(Expression<Func<Product, bool>> filter = null);
    }
}
