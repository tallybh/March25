namespace Testing_Example.contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);

    }
}
