using FluentValidation;
using Demo.Core.Application.DTOs;

public class KeyboardCreateDtoValidator : AbstractValidator<KeyboardCreateDto>
{
    public KeyboardCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.ImageFileName)
            .NotEmpty().WithMessage("Image file name is required.");

        RuleFor(x => x.Weight)
            .NotEmpty().WithMessage("Weight is required.");

        RuleFor(x => x.IsMechanical)
            .NotEmpty().WithMessage("IsMechanical is required.");
    }
}
