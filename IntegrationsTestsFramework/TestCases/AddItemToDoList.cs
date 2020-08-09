using IntegrationsTestsFramework.ElementHandlers;
using IntegrationsTestsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IntegrationsTestsFramework.TestCases
{
    [TestFixture]
    class AddItemToDoList : TestCase
    {
        [Test]
        public void TestAddItemToDoList()
        {
            ToDoListPage toDoListPage = new ToDoListPage();

            Browser.NavigateTo(toDoListPage);

            CollectionElementsHandler activitiesLabelsHandler = new CollectionElementsHandler(Browser, toDoListPage.ActivitiesLabelsByLocator);

            activitiesLabelsHandler.WaitForVisible(10);

            SingleElementHandler newActivityTextboxHandler = new SingleElementHandler(Browser, toDoListPage.NewActivityTextboxByLocator);

            string activityToAdd = "Read Web Calendar Handler article";

            newActivityTextboxHandler.Element.SendKeys(activityToAdd + Keys.Enter);

            activitiesLabelsHandler.VerifyContainsText(activityToAdd);
        }
    }
}
