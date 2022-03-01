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
            javaScriptAlertPage.ClickOnButtonForConfirmBox();

            IAlert alert = Driver.SwitchTo().Alert();

            // 2. Choose accept
            alert.Accept();
            string confirmMessageActual = javaScriptAlertPage.GetTextFromConfirmBox();

            Assert.AreEqual(expectedAlertText, confirmMessageActual, "Dont displays correct message on Accept!");
        }

        [Test]
        public void TestJavaScriptConfirmBoxCancelTest()
        {
            string expectedAlertText = "You pressed Cancel!";

            // 1. Click on Click me! button
            javaScriptAlertPage.ClickOnButtonForConfirmBox();

            IAlert alert = Driver.SwitchTo().Alert();

            // 2. Choose dismiss
            alert.Dismiss();
            string confirmMessageActual = javaScriptAlertPage.GetTextFromConfirmBox();

            Assert.AreEqual(expectedAlertText, confirmMessageActual, "Dont displays correct message on Accept!");
        }

        [Test]
        public void TestJavaScriptAlertBoxTest()
        {
            string expectedAlertText = "I am an alert box!";

            // 1. Click on Click me! button
            javaScriptAlertPage.ClickOnButtonForAlertBox();
            IAlert alert = Driver.SwitchTo().Alert();
            string alertMessageActual = alert.Text;

            // 2. Choose Accept
            alert.Accept();

            Assert.AreEqual(expectedAlertText, alertMessageActual, "Dont displays correct message on Accept!");
        }

        [Test]
        public void TestJavaScriptAlertBoxPromptTest()
        {
            string data = "Vladislav";
            string expectedAlertBoxPromptText = $"You have entered '{data}' !";

            // 1. Click for Promt Box button
            javaScriptAlertPage.ClickOnForPromptBoxButton();
            IAlert alert = Driver.SwitchTo().Alert();

            // 2. Send data and choose accept 
            alert.SendKeys(data);
            alert.Accept();
            string alertBoxPromptMessageActual = javaScriptAlertPage.GetTextFromPromptBox();

            Assert.AreEqual(expectedAlertBoxPromptText, alertBoxPromptMessageActual, "Dont displays correct message on Accept!");
        }
    }
}
