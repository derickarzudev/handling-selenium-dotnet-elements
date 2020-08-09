using IntegrationsTestsFramework.ElementHandlers;
using IntegrationsTestsFramework.Pages;
using NUnit.Framework;
using System;

namespace IntegrationsTestsFramework.TestCases
{
    [TestFixture]
    public class RemoveItemToDoList : TestCase
    {
        [Test]
        public void TestRemoveItemToDoList()
        {
            ToDoListPage toDoListPage = new ToDoListPage();

            Browser.NavigateTo(toDoListPage);

            CollectionElementsHandler activitiesLabelsHandler = new CollectionElementsHandler(Browser.WebDriver, toDoListPage.ActivitiesLabelsByLocator);

            activitiesLabelsHandler.WaitForVisible(10);

            CollectionElementsHandler removeActivityButtonsHandler = new CollectionElementsHandler(Browser.WebDriver, toDoListPage.RemoveActivityButtonsByLocator);

            int indexOfActivityToRemove = new Random().Next(0, activitiesLabelsHandler.Elements.Count - 1);

            string activityToRemove = activitiesLabelsHandler.Elements[indexOfActivityToRemove].Text;

            Assert.AreEqual(activitiesLabelsHandler.Elements.Count, removeActivityButtonsHandler.Elements.Count);

            activitiesLabelsHandler.Hover(indexOfActivityToRemove);

            removeActivityButtonsHandler.WaitForVisibleElement(10, indexOfActivityToRemove);

            activitiesLabelsHandler.SaveCount();

            removeActivityButtonsHandler.Elements[indexOfActivityToRemove].Click();

            activitiesLabelsHandler.WaitForSizeChange(10);

            activitiesLabelsHandler.VerifyDoesNotContainText(activityToRemove);
        }
    }
}
