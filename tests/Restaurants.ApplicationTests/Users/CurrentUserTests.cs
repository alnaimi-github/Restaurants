using FluentAssertions;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.ApplicationTests.Users;

public class CurrentUserTests
{
    //TestMethod_Scenario_ExpectedResult
    [Theory]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        // Arrange

        var currentUser = new CurrentUser("1", "test@gmail.com", [UserRoles.Admin, UserRoles.User], null, null);

        // Act

        var isInRole = currentUser.IsInRole(roleName);

        // Assert

        isInRole.Should().BeTrue();
    }
    [Fact]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        // Arrange

        var currentUser = new CurrentUser("1", "test@gmail.com", [UserRoles.Admin, UserRoles.User], null, null);

        // Act

        var isInRole = currentUser.IsInRole(UserRoles.Owner);

        // Assert

        isInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        // Arrange

        var currentUser = new CurrentUser("1", "test@gmail.com", [UserRoles.Admin, UserRoles.User], null, null);

        // Act

        var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

        // Assert

        isInRole.Should().BeFalse();
    }
}