using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundException(Guid id) : NotFoundException("Product", id);


public class ProductNotFoundException2 : NotFoundException
{
    public ProductNotFoundException2(Guid id) : base("Product", id)
    {
    }
}