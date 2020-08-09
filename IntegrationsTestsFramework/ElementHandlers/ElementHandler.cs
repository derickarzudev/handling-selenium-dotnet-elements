using OpenQA.Selenium;

namespace IntegrationsTestsFramework.ElementHandlers
{
    public abstract class ElementHandler
    {
        protected readonly Browser Browser;
        protected readonly By ByLocator;

        public ElementHandler(Browser browser, By byLocator)
        {
            Browser = browser;
            ByLocator = byLocator;
        }

        public abstract void WaitForVisible(int timeoutSeconds);

        public abstract void WaitForInvisible(int timeoutSeconds);
    }
}
