using FluentValidation;
using OrderManagementApi.DTO.Product.Request;

namespace OrderManagementApi.Service.Validator.Product
{
    public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}