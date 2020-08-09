using OpenQA.Selenium;

namespace IntegrationsTestsFramework.ElementHandlers
{
    public abstract class ElementHandler
    {
        protected readonly IWebDriver WebDriver;
        protected readonly By ByLocator;

        public ElementHandler(IWebDriver webDriver, By byLocator)
        {
            WebDriver = webDriver;
            ByLocator = byLocator;
        }

        public abstract void WaitForVisible(int timeoutSeconds);

        public abstract void WaitForInvisible(int timeoutSeconds);
    }
}
