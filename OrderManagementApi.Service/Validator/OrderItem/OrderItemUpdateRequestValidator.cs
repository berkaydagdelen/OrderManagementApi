using FluentValidation;
using OrderManagementApi.DTO.OrderItem.Request;

namespace OrderManagementApi.Service.Validator.OrderItem
{
    public class OrderItemUpdateRequestValidator : AbstractValidator<OrderItemUpdateRequest>
    {
        public OrderItemUpdateRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

        }
    }
}