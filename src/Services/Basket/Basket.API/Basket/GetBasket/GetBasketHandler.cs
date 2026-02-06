namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName): IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);



internal class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        // TODO: get basket from database
        // var barket = await _repository.GetBasket(request.UserName);
        
        // var cart = await session.Query<ShoppingCart>()
        //     .Where(c => c.UserName == query.UserName)
        //     .SingleOrDefaultAsync(cancellationToken);
        // return new GetBasketResult(cart ?? throw new NotFoundException("Data not found"));
        
        return new GetBasketResult(new ShoppingCart("swn"));
    }
}