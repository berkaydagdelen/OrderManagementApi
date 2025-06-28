using FluentValidation;
using OrderManagementApi.DTO.OrderItem.Request;

namespace OrderManagementApi.Service.Validator.OrderItem
{
    public class OrderItemSaveRequestValidator : AbstractValidator<OrderItemSaveRequest>
    {
        public OrderItemSaveRequestValidator()
        {
            RuleFor(p => p.OrderId).NotEmpty();

        }
    }
}