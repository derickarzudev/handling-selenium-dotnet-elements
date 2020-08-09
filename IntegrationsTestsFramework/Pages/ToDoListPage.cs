using IntegrationsTestsFramework.ElementHandlers;
using OpenQA.Selenium;

namespace IntegrationsTestsFramework.Pages
{
    public class ToDoListPage : Page
    {
        public By ActivitiesLabelsByLocator = By.CssSelector("body ul li");
        public By NewActivityTextboxByLocator = By.CssSelector("body input");
        public By RemoveActivityButtonsByLocator = By.XPath("//i[@class=\"fa fa-trash\"]");

        public ToDoListPage()
        {
            Url = $"{BaseUrl}/To-Do-List/index.html";
        }
    }
}
