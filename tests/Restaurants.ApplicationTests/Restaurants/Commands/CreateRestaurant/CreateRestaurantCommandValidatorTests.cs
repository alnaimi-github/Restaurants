using FluentValidation.TestHelper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Xunit;

namespace Restaurants.ApplicationTests.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidatorTests
{
    [Fact]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var command = new CreateRestaurantCommand
        {
            Name = "Test",
            Category = "Italian",
            ContentEmail = "test@test.com",
            PostalCode = "12-333",
            Description = "Restaurant one"
        };
        var validator=new CreateRestaurantCommandValidator();
        // Act
       var result= validator.TestValidate(command);

        // Assert
      result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Validator_ForInValidCommand_ShouldHaveValidationErrors()
    {
        // Arrange
        var command = new CreateRestaurantCommand
        {
            Name = "WW",
            Category = "Italia",
            ContentEmail = "test@test.com",
            PostalCode = "12-33",
            Description = "Restaurant one"
        };
        var validator = new CreateRestaurantCommandValidator();
        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Name);
        result.ShouldHaveValidationErrorFor(r => r.Category);
        result.ShouldHaveValidationErrorFor(r => r.PostalCode);
    }

    [Theory]
    [InlineData("Italian")]
    [InlineData("Mexican")]
    [InlineData("Japanese")]
    [InlineData("American")]
    [InlineData("Indian")]
    public void Validator_ForValidCategory_ShouldNotHaveValidationErrorsForCategoryProperty(string category)
    {
        // Arrange
        var validator = new CreateRestaurantCommandValidator();
        var command = new CreateRestaurantCommand { Category = category };

        // Act 
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r=>r.Category);
    }

    [Theory]
    [InlineData("10323")]
    [InlineData("102-20")]
    [InlineData("10 120")]
    [InlineData("10-2 20")]
    public void Validator_ForInValidPostalCode_ShouldHaveValidationErrorsForPostalCodeProperty(string postalCode)
    {
        // Arrange
        var validator = new CreateRestaurantCommandValidator();
        var command = new CreateRestaurantCommand { PostalCode = postalCode };

        // Act 
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.PostalCode);
    }
}