using Chat.BLL.ViewModels;
using FluentValidation;

namespace Chat.BLL.Validators;

public class CreateMessageValidator : AbstractValidator<CreateMessageViewModel>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.UserId)
            .GreaterThan(0);
    }
}