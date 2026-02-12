namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;
public record UpdateOrderResult(bool IsSuccess);


public class UpdateOrderCommandValidations : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidations()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("ID is required");
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
    }
}