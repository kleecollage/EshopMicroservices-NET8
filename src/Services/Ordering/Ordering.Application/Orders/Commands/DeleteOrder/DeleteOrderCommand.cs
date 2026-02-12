namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;
public record DeleteOrderResult(bool IsSuccess);


public class DeleteOrderCommandValidations : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidations()
    {
        RuleFor(c => c.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}