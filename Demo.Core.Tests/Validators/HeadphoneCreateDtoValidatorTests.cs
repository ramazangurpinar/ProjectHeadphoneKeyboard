using Demo.Core.Application.DTOs;
using Demo.Core.Application.Validators;
using FluentValidation.TestHelper;

namespace Demo.Core.Tests.Validators
{
    public class HeadphoneCreateDtoValidatorTests
    {
        private readonly HeadphoneCreateDtoValidator _validator;

        public HeadphoneCreateDtoValidatorTests()
        {
            _validator = new HeadphoneCreateDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new HeadphoneCreateDto { Name = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Valid()
        {
            var model = new HeadphoneCreateDto { Name = "Bose QC35" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Price_Is_Less_Than_Or_Equal_Zero()
        {
            var model = new HeadphoneCreateDto { Price = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }
    }
}
