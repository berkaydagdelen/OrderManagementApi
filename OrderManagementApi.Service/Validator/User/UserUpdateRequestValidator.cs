using FluentValidation;
using OrderManagementApi.DTO.User.Request;

namespace OrderManagementApi.Service.Validator.User
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
} 