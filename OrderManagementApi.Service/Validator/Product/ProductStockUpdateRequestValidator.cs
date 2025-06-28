using FluentValidation;
using OrderManagementApi.DTO.Product.Request;

namespace OrderManagementApi.Service.Validator.Product
{
    public class ProductStockUpdateRequestValidator : AbstractValidator<ProductStockUpdateRequest>
    {
        public ProductStockUpdateRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}