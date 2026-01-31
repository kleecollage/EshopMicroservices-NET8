using MediatR;

namespace Catalog.API.Products.CreateProduct;

public abstract record CreatedProductCommand( string Name, List<string> Category, string Description, string ImageFile,
    decimal Price ): IRequest<CreateProductResult>;
public abstract record CreateProductResult(Guid Id);

internal class CreateProductComamndHandler: IRequestHandler<CreatedProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreatedProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}