using DevApi.Entities;

namespace DevApi.Repositories;

public interface IProductRepo
{
    Task<Product> GetProductById(int id);
    // Task<IEnumerable<Product>> GetAllProducts();
    // Task<Product> CreateProduct(Product product);
    // Task<Product> UpdateProduct(Product product);
    // Task<bool> DeleteProduct(int id);
}