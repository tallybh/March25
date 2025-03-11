using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Services
{
    public class ProductRepository : IProductsRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Milk", Price = 10.0m });
        }

        public void AddProduct(Product product)
        {
            var id = products.Max(p => p.Id) + 1;
            product.Id = id;
            products.Add(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public Product GetProduct(int id)
        {
           return products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var p = products.FirstOrDefault(p => p.Id == product.Id);
            if (p != null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
            }
        }
    }
}
