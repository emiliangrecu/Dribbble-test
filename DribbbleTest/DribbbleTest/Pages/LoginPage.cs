using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using DribbbleTest.Helpers;

namespace DribbbleTest.Pages
{
    public class LoginPage : DriverHelper
    {
        IWebElement usernameInput => driver.FindElement(By.CssSelector("#login"));
        IWebElement passwordInput => driver.FindElement(By.CssSelector("#password"));
        IWebElement signInButton => driver.FindElement(By.CssSelector(".button.form-sub"));
        private readonly By uploadButton = By.XPath("//a[contains(text(),'Upload')]");

        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(Constants.LoginUrl);
        }

        public void Login()
        {
            usernameInput.SendKeys(Constants.Username);
            passwordInput.SendKeys(Constants.Password);
            signInButton.Click();
            
            WebDriverWait webDriverWait = new(driver, TimeSpan.FromSeconds(20));
            webDriverWait.Until(ExpectedConditions.ElementExists(uploadButton));
        }

    }
}
