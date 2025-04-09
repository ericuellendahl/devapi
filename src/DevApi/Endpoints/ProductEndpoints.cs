
namespace DevApi.Endpoints;

public static class ProductEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", () =>
        {
            var produto = new { id = 1, name = "produto" };
            return Results.Json(produto);
        });
    }
}