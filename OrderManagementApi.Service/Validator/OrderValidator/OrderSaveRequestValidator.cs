using FluentValidation;
using OrderManagementApi.DTO.BedType.Request;

namespace OrderManagementApi.Service.Validator.OrderValidator
{
    public class OrderSaveRequestValidator : AbstractValidator<OrderSaveRequest>
    {
        public OrderSaveRequestValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();

        }
    }
}
