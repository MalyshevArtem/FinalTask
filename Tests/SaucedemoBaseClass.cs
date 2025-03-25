using OpenQA.Selenium;
using Tests.Utilities;

namespace Tests;

public class SaucedemoBaseClass : IDisposable
{
    protected readonly IWebDriver driver;

    public SaucedemoBaseClass(BrowserType browserType)
    {
        driver = WebDriverFactory.CreateWebDriver(browserType);
        driver.Manage().Window.Maximize();
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