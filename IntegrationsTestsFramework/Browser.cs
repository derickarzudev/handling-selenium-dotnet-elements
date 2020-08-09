using IntegrationsTestsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntegrationsTestsFramework
{
    public class Browser
    {
        public IWebDriver WebDriver { private set; get; }

        public Browser()
        {
            WebDriver = new ChromeDriver(@"C:\Users\arzud\OneDrive\Documentos\Engineering\QA Automation\selenium_code_structure\IntegrationsTestsFramework\IntegrationsTestsFramework\bin\Debug\netcoreapp3.1");
        }

        public void NavigateTo(Page page)
        {
            WebDriver.Url = page.Url;
        }

        public void Close()
        {
            WebDriver.Close();
        }
    }
}
