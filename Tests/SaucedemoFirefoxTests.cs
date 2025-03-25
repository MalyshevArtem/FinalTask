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
        logger.Log($"LogInAllCleared_ReturnErrorMessage started with username: {username}, password: {password}, expected: {expected}");

        // arrange
        var indexPage = new IndexPage(driver);

        // act
        string errorMessage = indexPage.Open().LogInAllCleared(username, password);

        // assert
        errorMessage.Should().Contain(expected);

        logger.Log($"LogInAllCleared_ReturnErrorMessage result: Actual error message was {errorMessage}, expected {expected}.");
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Password is required")]
    public void LogInPasswordCleared_ReturnErrorMessage(string username, string password, string expected)
    {
        logger.Log($"LogInPasswordCleared_ReturnErrorMessage started with username: {username}, password: {password}, expected: {expected}");

        // arrange
        var indexPage = new IndexPage(driver);

        // act
        string errorMessage = indexPage.Open().LogInPasswordCleared(username, password);

        // assert
        errorMessage.Should().Contain(expected);

        logger.Log($"LogInPasswordCleared_ReturnErrorMessage result: Actual error message was {errorMessage}, expected {expected}.");
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Swag Labs")]
    public void LogIn_ReturnInventoryTitle(string username, string password, string expected)
    {
        logger.Log($"LogIn_ReturnInventoryTitle started with username: {username}, password: {password}, expected: {expected}");

        // arrange
        var indexPage = new IndexPage(driver);

        // act
        InventoryPage inventoryPage = indexPage.Open().LogIn(username, password);

        // assert
        inventoryPage.GetTtile().Should().Be(expected);

        logger.Log($"LogIn_ReturnInventoryTitle result: Actual title was {inventoryPage.GetTtile()}, expected {expected}.");
    }
}
