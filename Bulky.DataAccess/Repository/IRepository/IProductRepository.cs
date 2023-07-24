using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
        Product Get(int id);
        void Remove(int id);
    }
}
