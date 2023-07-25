using Bulky.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        // Add properties for the repositories
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        // Add a method to get the DbSet<Product>
        public IQueryable<Product> GetProductsDbSet()
        {
            return _db.Set<Product>();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
