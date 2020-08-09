using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IntegrationsTestsFramework.ElementHandlers
{
    public class CollectionElementsHandler : ElementHandler
    {
        private int Count { get; set; }

        public ReadOnlyCollection<IWebElement> Elements => WebDriver.FindElements(ByLocator);

        public CollectionElementsHandler(IWebDriver webDriver, By byLocator) : base(webDriver, byLocator) { }

        public void SaveCount()
        {
            Count = Elements.Count;
        }

        public override void WaitForVisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(ByLocator));
        }

        public void WaitForVisibleElement(int timeoutSeconds, int index)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(ByLocator));
            wait.Until(driver => driver.FindElements(ByLocator)[index].Displayed);
        }

        public override void WaitForInvisible(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => (ExpectedConditions.VisibilityOfAllElementsLocatedBy(ByLocator))(driver) == null);
        }

        public void WaitForSizeChange(int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => driver.FindElements(ByLocator).Count != Count);
        }

        public void Hover(int index)
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(Elements[index]).Perform();
        }

        public void VerifyContainsText(string expectedText)
        {
            CollectionAssert.Contains(Elements.Select(element => element.Text), expectedText);
        }

        public void VerifyDoesNotContainText(string expectedText)
        {
            CollectionAssert.DoesNotContain(Elements.Select(element => element.Text), expectedText);
        }
    }
}
