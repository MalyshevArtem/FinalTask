using OpenQA.Selenium;
using PageObjects;
using Tests.Utilities;

namespace Tests;

public class SaucedemoTests : IDisposable
{
    private readonly IWebDriver driver;

    public SaucedemoTests()
    {
        driver = WebDriverFactory.CreateWebDriver(BrowserType.Firefox);
        driver.Manage().Window.Maximize();
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
        Assert.Contains(expected, errorMessage);
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
        Assert.Contains(expected, errorMessage);
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
        Assert.Equal(expected, inventoryPage.GetTtile());
    }

    public void Dispose()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
