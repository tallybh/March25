using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Services
{
    public class ProductsRepositoryMock : IProductsRepository
    {
        private List<Product> products;

        public ProductsRepositoryMock()
        {
            products.Add(new Product { Id = 1, Name = "Milk", Price = 10.0m });
        }
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
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

        bool IProductsRepository.DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
