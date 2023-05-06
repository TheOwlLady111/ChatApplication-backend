using Chat.BLL.ViewModels;
using FluentValidation;

namespace Chat.BLL.Validators;

public class RegisterValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(8);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .MaximumLength(8);
    }
}