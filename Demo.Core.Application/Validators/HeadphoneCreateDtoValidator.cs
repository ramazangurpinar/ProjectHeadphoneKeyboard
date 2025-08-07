using FluentValidation;
using Demo.Core.Application.DTOs;

namespace Demo.Core.Application.Validators
{
    public class HeadphoneCreateDtoValidator : AbstractValidator<HeadphoneCreateDto>
    {
        public HeadphoneCreateDtoValidator()
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

            RuleFor(x => x.Manufacturer)
                .NotEmpty().WithMessage("Manufacturer is required.");

            RuleFor(x => x.BatteryLife)
                .NotEmpty().WithMessage("Battery life is required.");

            RuleFor(x => x.NoiseCancellationType)
                .NotEmpty().WithMessage("Noise cancellation type is required.");
        }
    }
}