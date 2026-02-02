namespace Catalog.API.Exceptions;

public class ProductNotFoundException() : Exception("Product not found!");

public class ProductNotFoundException2 : Exception
{
    public ProductNotFoundException2() : base("Product not found!")
    {
        
    }
}