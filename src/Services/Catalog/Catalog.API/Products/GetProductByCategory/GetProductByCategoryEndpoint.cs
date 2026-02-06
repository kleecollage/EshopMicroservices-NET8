namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryRequest(string Category = null!, int? PageNumber = 1, int? PageSize = 10);
public record GetProductByCategoryResponse(IEnumerable<Product> Products);


public class GetProductByCategoryEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products/category/{category}",
                async ([AsParameters] GetProductByCategoryRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductByCategoryQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductByCategoryResponse>();
                
                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get product by Category")
            .WithDescription("Get product by Category");
    }
}