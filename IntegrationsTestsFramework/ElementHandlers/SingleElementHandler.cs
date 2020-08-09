using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace IntegrationsTestsFramework.ElementHandlers
{
    class SingleElementHandler : ElementHandler
    {
        public IWebElement Element => Browser.WebDriver.FindElement(ByLocator);

        public SingleElementHandler(Browser browser, By byLocator) : base(browser, byLocator) { }

        public override void WaitForVisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
        }

        public override void WaitForInvisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ByLocator));
        }

        public void Hover()
        {
            Actions action = new Actions(Browser.WebDriver);
            action.MoveToElement(Element).Perform();
        }
    }
}
