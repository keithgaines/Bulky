using Bulky.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
        }
    }
}
