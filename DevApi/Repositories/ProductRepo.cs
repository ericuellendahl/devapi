using DevApi.Entities;

namespace DevApi.Repositories;

public class ProductRepo : IProductRepo
{
    public async Task<Product> GetProductById(int Id)
    {
        return await Task.Run(() => new Product { Id = Id, Description = "Product Description", Price = 10.0, Stock = 100 });
    }
}