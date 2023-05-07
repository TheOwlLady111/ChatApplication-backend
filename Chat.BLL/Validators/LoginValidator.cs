using Chat.BLL.ViewModels;
using FluentValidation;

namespace Chat.BLL.Validators;

public class LoginValidator : AbstractValidator<LoginViewModel>
{
    public LoginValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(8);
    }
}