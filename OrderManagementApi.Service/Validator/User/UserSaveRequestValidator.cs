using FluentValidation;
using OrderManagementApi.DTO.User.Request;

namespace OrderManagementApi.Service.Validator.User
{
    public class UserSaveRequestValidator : AbstractValidator<UserSaveRequest>
    {
        public UserSaveRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
} 