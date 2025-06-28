using FluentValidation;
using OrderManagementApi.DTO.BedType.Request;

namespace OrderManagementApi.Service.Validator.OrderValidator
{
    public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
    {
        public OrderUpdateRequestValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();

        }
    }
}
