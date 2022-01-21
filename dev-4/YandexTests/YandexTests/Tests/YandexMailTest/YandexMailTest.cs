using NUnit.Framework;
using YandexTests.Pages;
using System.Collections.Generic;
using YandexTests.Tests;

namespace YandexTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class YandexMailTest : BaseTest
    {
        private YandexMailPage yandexMailPage;
        private AuthorizationPage authorizationPage;

        [SetUp]
        public void InitializeYandexMailTest()
        {
            yandexMailPage = new YandexMailPage(Driver);
            authorizationPage = new AuthorizationPage(Driver);
            yandexMailPage.GoTo();
        }

        private static IEnumerable<TestCaseData> AddDifferentCredentials()
        {
            yield return new TestCaseData("vladik.luksha", "Vl34567");
            yield return new TestCaseData("", "");
        }

        [Test, TestCaseSource("AddDifferentCredentials")]
        public void LoginYandexMail(string userName, string password)
        {
            bool expected = true;
            authorizationPage = yandexMailPage.LogInAuthorizationPage();
            authorizationPage.LoginAuthorizationPage(userName, password);
            var actual = authorizationPage.WaitForAfterLoginPage();

            Assert.AreEqual(expected, actual, "Login failed on Yandex Mail page!");
        }
    }
}