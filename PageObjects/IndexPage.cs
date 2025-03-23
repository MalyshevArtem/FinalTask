using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObjects;

public class IndexPage
{
    private readonly IWebDriver driver;

    private readonly By usernameLocator = By.CssSelector("[data-test='username']");
    private readonly By passwordLocator = By.CssSelector("[data-test='password']");
    private readonly By loginLocator = By.CssSelector("[data-test='login-button']");
    private readonly By errorLocator = By.CssSelector("[data-test='error']");

    public string Url { get; } = "https://www.saucedemo.com/";

    public IndexPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IndexPage Open()
    {
        driver.Url = Url;
        return this;
    }

    private void ClearInput(IWebElement input)
    {
        var actions = new Actions(driver);

        actions.Click(input)
        .KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
        .SendKeys(Keys.Backspace)
        .Perform();
    }

    private string GetErrorMessage()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        var errorElement = wait.Until(d => d.FindElement(errorLocator));

        return errorElement.Text;
    }

    public string LogInAllCleared(string username, string password)
    {
        var usernameInput = driver.FindElement(usernameLocator);
        var passwordInput = driver.FindElement(passwordLocator);
        var loginButton = driver.FindElement(loginLocator);

        usernameInput.SendKeys(username);
        ClearInput(usernameInput);

        passwordInput.SendKeys(password);
        ClearInput(passwordInput);

        loginButton.Click();

        return GetErrorMessage();
    }

    public string LogInPasswordCleared(string username, string password)
    {
        var usernameInput = driver.FindElement(usernameLocator);
        var passwordInput = driver.FindElement(passwordLocator);
        var loginButton = driver.FindElement(loginLocator);

        usernameInput.SendKeys(username);

        passwordInput.SendKeys(password);
        ClearInput(passwordInput);

        loginButton.Click();

        return GetErrorMessage();
    }

    public InventoryPage LogIn(string username, string password)
    {
        var usernameInput = driver.FindElement(usernameLocator);
        var passwordInput = driver.FindElement(passwordLocator);
        var loginButton = driver.FindElement(loginLocator);

        usernameInput.SendKeys(username);
        passwordInput.SendKeys(password);

        loginButton.Click();

        return new InventoryPage(driver);
    }
}
