using OpenQA.Selenium;

namespace PageObjects;

public class InventoryPage
{
    private readonly IWebDriver driver;

    public InventoryPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public string GetTtile()
    {
        return driver.Title;
    }
}
