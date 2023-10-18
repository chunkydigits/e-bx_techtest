using FluentValidation;

namespace TechTest.Validators;

public sealed class RequiredStringValidator : AbstractValidator<string>
{
    public RequiredStringValidator()
    {
        RuleFor(x => x).NotNull().NotEmpty().MinimumLength(2);
    }
}