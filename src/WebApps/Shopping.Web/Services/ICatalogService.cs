namespace Shopping.Web.Services;

public interface ICatalogService
{
    Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);
    Task<GetProductByIdResponse> GetProductById(Guid id);
    Task<GetProductByCategoryResponse> GetProductByCategory(string category);
}