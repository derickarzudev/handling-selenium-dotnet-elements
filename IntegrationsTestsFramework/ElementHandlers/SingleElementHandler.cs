using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace IntegrationsTestsFramework.ElementHandlers
{
    public class SingleElementHandler : ElementHandler
    {
        public IWebElement Element => WebDriver.FindElement(ByLocator);

        public SingleElementHandler(IWebDriver webDriver, By byLocator) : base(webDriver, byLocator) { }

        public override void WaitForVisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
        }

        public override void WaitForInvisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ByLocator));
        }

        public void Hover()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(Element).Perform();
        }
    }
}
