using PageObjects;
using Tests.Utilities;
using FluentAssertions;

namespace Tests;

public class SaucedemoFirefoxTests : SaucedemoBaseClass
{
    public SaucedemoFirefoxTests() : base(BrowserType.Firefox)
    {
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Username is required")]
    public void LogInAllCleared_ReturnErrorMessage(string username, string password, string expected)
    {
        // arrange
        var indexPage = new IndexPage(driver);

        // act
        string errorMessage = indexPage.Open().LogInAllCleared(username, password);

        // assert
        errorMessage.Should().Contain(expected);
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Password is required")]
    public void LogInPasswordCleared_ReturnErrorMessage(string username, string password, string expected)
    {
        // arrange
        var indexPage = new IndexPage(driver);

        // act
        string errorMessage = indexPage.Open().LogInPasswordCleared(username, password);

        // assert
        errorMessage.Should().Contain(expected);
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Swag Labs")]
    public void LogIn_ReturnInventoryTitle(string username, string password, string expected)
    {
        // arrange
        var indexPage = new IndexPage(driver);

        // act
        InventoryPage inventoryPage = indexPage.Open().LogIn(username, password);

        // assert
        inventoryPage.GetTtile().Should().Be(expected);
    }
}
