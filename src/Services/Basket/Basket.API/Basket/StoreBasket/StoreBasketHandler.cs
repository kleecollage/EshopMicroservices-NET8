using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(c => c.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(c => c.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}



internal class StoreBasketCommandHandler(IBasketRepository repository, DiscountService.DiscountServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;
        // Communicate with Discount.Grpc
        await DeductDiscount(cart, cancellationToken);
        // Store basket in database (use Marten upsert - if exist = update, if not exist = create) and update cache
        await repository.StoreBasket(cart, cancellationToken);

        return new StoreBasketResult(cart.UserName);
    }

    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        // Communicate with Discount.Grpc and calculate latest prices of products into basket
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName =  item.ProductName }, 
                cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}