using WebApiExample.Models;

namespace WebApiExample.Contracts
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
