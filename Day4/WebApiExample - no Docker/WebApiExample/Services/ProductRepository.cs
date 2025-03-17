
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Services
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
             _context = context;
        }
    public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
