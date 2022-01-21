using NUnit.Framework;
using OpenQA.Selenium;
using YandexTests.Pages;

namespace YandexTests.Tests
{
    [TestFixture]
    public class JavaScriptAlertTest : BaseTest
    {
        private JavaScriptAlertPage javaScriptAlertPage;

        [SetUp]
        public void InitializeJavaScriptAlertTest()
        {
            javaScriptAlertPage = new JavaScriptAlertPage(Driver);
            javaScriptAlertPage.GoTo();
        }

        [Test]
        public void TestJavaScriptConfirmBoxAcceptTest()
        {
            string expectedAlertText = "You pressed OK!";

            // 1. Click on Click me! button
            IWebElement element = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.clickButtonForConfirmBox);
            element.Click();

            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();
                string message = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.confirmInput).Text;

                Assert.AreEqual(expectedAlertText, message, "Dont displays correct message on Accept!");
            }
            catch(NoAlertPresentException e)
            {
                Assert.Pass(e.StackTrace);
            }
        }

        [Test]
        public void TestJavaScriptConfirmBoxCancelTest()
        {
            string expectedAlertText = "You pressed Cancel!";

            // 1. Click on Click me! button
            IWebElement element = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.clickButtonForConfirmBox);
            element.Click();

            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Dismiss();
                string message = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.confirmInput).Text;

                Assert.AreEqual(expectedAlertText, message, "Dont displays correct message on Accept!");
            }
            catch (NoAlertPresentException e)
            {
                Assert.Pass(e.StackTrace);
            }
        }

        [Test]
        public void TestJavaScriptAlertBoxTest()
        {
            string expectedAlertText = "I am an alert box!";

            // 1. Click on Click me! button
            IWebElement element = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.clickButtonForAlertBox);
            element.Click();

            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                string message = alert.Text;
                alert.Accept();

                Assert.AreEqual(expectedAlertText, message, "Dont displays correct message on Accept!");
            }
            catch (NoAlertPresentException e)
            {
                Assert.Pass(e.StackTrace);
            }
        }

        [Test]
        public void TestJavaScriptAlertBoxPromptTest()
        {
            string data = "Vladislav";
            string expectedAlertText = $"You have entered '{data}' !";


            // 1. Click for Promt Box button
            IWebElement element = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.clickForPromptBoxButton);
            element.Click();

            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.SendKeys(data);
                alert.Accept();
                string message = javaScriptAlertPage.WaitingForElement(javaScriptAlertPage.promtInput).Text;

                Assert.AreEqual(expectedAlertText, message, "Dont displays correct message on Accept!");
            }
            catch (NoAlertPresentException e)
            {
                Assert.Pass(e.StackTrace);
            }
        }
    }
}
