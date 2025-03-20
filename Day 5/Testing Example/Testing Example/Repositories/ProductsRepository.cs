using Testing_Example.contracts;

namespace Testing_Example.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        public async Task<Product> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
