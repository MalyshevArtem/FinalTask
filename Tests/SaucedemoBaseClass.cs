using OpenQA.Selenium;
using Tests.Utilities;

namespace Tests;

public class SaucedemoBaseClass : IDisposable
{
    protected readonly IWebDriver driver;
    protected readonly Logger logger;

    public SaucedemoBaseClass(BrowserType browserType)
    {
        driver = WebDriverFactory.CreateWebDriver(browserType);
        driver.Manage().Window.Maximize();

        logger = new Logger();
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