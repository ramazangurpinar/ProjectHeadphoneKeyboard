using Demo.Core.Application.DTOs;
using Demo.Core.Application.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Demo.Core.Tests.Validators
{
    public class KeyboardCreateDtoValidatorTests
    {
        private readonly KeyboardCreateDtoValidator _validator;

        public KeyboardCreateDtoValidatorTests()
        {
            _validator = new KeyboardCreateDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new KeyboardCreateDto { Name = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Valid()
        {
            var model = new KeyboardCreateDto { Name = "Logitech G915" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Price_Is_Less_Than_Or_Equal_Zero()
        {
            var model = new KeyboardCreateDto { Price = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Price_Is_Positive()
        {
            var model = new KeyboardCreateDto { Price = 99.99 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Should_Have_Error_When_Weight_Is_Empty()
        {
            var model = new KeyboardCreateDto { Weight = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Weight);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Weight_Is_Valid()
        {
            var model = new KeyboardCreateDto { Weight = "450g" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Weight);
        }
    }
}
