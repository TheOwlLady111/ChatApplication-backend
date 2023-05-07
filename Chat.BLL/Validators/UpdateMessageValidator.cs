using Chat.BLL.ViewModels;
using FluentValidation;

namespace Chat.BLL.Validators;

public class UpdateMessageValidator : AbstractValidator<UpdateMessageViewModel>
{
    public UpdateMessageValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}