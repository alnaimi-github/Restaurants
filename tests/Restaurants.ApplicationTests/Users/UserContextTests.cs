using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.ApplicationTests.Users;

public class UserContextTests
{
    [Fact]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        //Arrange
        var dateOfBirth = new DateOnly(2002, 2, 1);
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>
        {
              new(ClaimTypes.NameIdentifier,"1"),
              new (ClaimTypes.Email,"test@test.com"),
              new(ClaimTypes.Role,UserRoles.Admin),
              new(ClaimTypes.Role,UserRoles.User),
              new("Nationality","Yemeni"),
              new("DateOfBirth",dateOfBirth.ToString("MM/dd/yyyy"))
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"test"));

        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext
        {
            User = user
        });

        var userContext = new UserContext(httpContextAccessorMock.Object);
        

        //Act
       var currentUser= userContext.GetCurrentUser();

        //Assert
        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@test.com");
        currentUser.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
        currentUser.Nationality.Should().Be("Yemeni");
        currentUser.DateOfBirth.Should().Be(dateOfBirth);
    }

    [Fact]
    public void CurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
    {
        //Arrange
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);
        var userContext = new UserContext(httpContextAccessorMock.Object);

        //Act 
        Action action = () => userContext.GetCurrentUser();

        //Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("User context is not present");

    }
}