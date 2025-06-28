using FluentValidation;
using OrderManagementApi.DTO.Product.Request;

namespace OrderManagementApi.Service.Validator.Product
{
    public class ProductSaveRequestValidator : AbstractValidator<ProductSaveRequest>
    {
        public ProductSaveRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}