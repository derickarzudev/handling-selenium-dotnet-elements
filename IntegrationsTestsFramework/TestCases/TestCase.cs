using NUnit.Framework;

namespace IntegrationsTestsFramework.TestCases
{
    public class TestCase
    {
        protected Browser Browser;

        [SetUp]
        public void BeforeTest()
        {
            Browser = new Browser();
        }

        [TearDown]
        public void AfterTest()
        {
            Browser.Close();
        }
    }
}
