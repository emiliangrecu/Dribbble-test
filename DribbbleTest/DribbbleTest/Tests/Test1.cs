using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DribbbleTest.Helpers;
using DribbbleTest.Pages;

namespace DribbbleTest.Tests
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();

            loginPage.GoToLoginPage();
            loginPage.Login();
            homePage.GoToDashboardnPage();
            homePage.IsAllOptionSelected();

            homePage.ClickOnFilter();
            homePage.SelectTimeframe("This Past Week");
            homePage.ClearTimeframeFilter();

            homePage.SearchByTag("food");

            for (int i = 1; i <= 4; i++)
            {
                homePage.AreCardsDisplayed(i);
            }

            homePage.AreSaveAndLikeDisplayed();
            homePage.AreLikesAndViewsDisplayed();
        }

        [TearDown]
        public void After()
        {
            driver.Quit();
        }

    }
}
