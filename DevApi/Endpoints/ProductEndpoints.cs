using DevApi.Repositories;

namespace DevApi.Endpoints;

public static class ProductEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (int id, IProductRepo productRepo) =>
        {
            var product = await productRepo.GetProductById(id);
            return product;
        });
    }
}