using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Tests.Utilities;

public static class WebDriverFactory
{
    public static IWebDriver CreateWebDriver(BrowserType type)
    {
        switch (type)
        {
            case BrowserType.Firefox:
            {
                return new FirefoxDriver();
            }
            default:
            {
                var options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");

                return new ChromeDriver(options);
            }
        }
    }
}
