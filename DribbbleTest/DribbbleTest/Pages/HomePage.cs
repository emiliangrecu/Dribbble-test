using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using DribbbleTest.Helpers;

namespace DribbbleTest.Pages
{
    public class HomePage : DriverHelper
    {
        IWebElement allOption => driver.FindElement(By.CssSelector(".category.sets-path.active > [title = 'All']"));
        IWebElement filtersButton => driver.FindElement(By.CssSelector(".form-btn.outlined.filters-toggle-btn"));
        IWebElement tagInput => driver.FindElement(By.CssSelector("#tag"));
        IWebElement timeframeDropdown => driver.FindElement(By.CssSelector(".find-shots-timeframe .btn-dropdown"));
        IWebElement clearTimeframeFilterButton => driver.FindElement(By.CssSelector(".find-shots-timeframe .clear-filter"));
        IWebElement cardUsername => driver.FindElement(By.CssSelector(".display-name"));
        IWebElement cardName => driver.FindElement(By.CssSelector(".shot-title"));
        IWebElement saveShotIcon => driver.FindElement(By.CssSelector(".bucket-shot.form-btn"));
        IWebElement likeShotIcon => driver.FindElement(By.CssSelector("#shots-like-button"));
        IWebElement numberOfLikes => driver.FindElement(By.CssSelector(".js-shot-likes-count"));
        IWebElement numberOfViews => driver.FindElement(By.CssSelector(".js-shot-views-count "));

        public void GoToDashboardnPage()
        {
            driver.Navigate().GoToUrl(Constants.DashboardUrl);
        }

        public bool IsAllOptionSelected()
        {
            try
            {
                return allOption.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ClickOnFilter()
        {
            filtersButton.Click();
        }

        public void SelectTimeframe(string TimePeriod)
        {
            timeframeDropdown.Click();
            driver.FindElement(By.XPath($"//a[text()='{TimePeriod}']")).Click();
            ExpectedConditions.ElementExists(By.XPath($"//span[contains(text(), '{TimePeriod}']"));
        }

        public void ClearTimeframeFilter()
        {
            clearTimeframeFilterButton.Click();
        }

        public void SearchByTag(string tag)
        {
            tagInput.SendKeys(tag);
            tagInput.SendKeys(Keys.Enter);
            DateTime startingTime = DateTime.Now;
            WebDriverWait webDriverWait = new(driver, TimeSpan.FromSeconds(3));
            webDriverWait.PollingInterval = TimeSpan.FromSeconds(3);
            webDriverWait.Until((IWebDriver d) => DateTime.Now - startingTime - TimeSpan.FromSeconds(3) > TimeSpan.Zero);
        }

        public bool AreCardsDisplayed(int i)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(cardUsername).Perform();
            try
            {
                return driver.FindElement(By.XPath($"(//img[contains(@alt, 'food')])[{i}]")).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AreSaveAndLikeDisplayed()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(cardName).Perform();
            try
            {
            return saveShotIcon.Displayed
                && likeShotIcon.Displayed;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool AreLikesAndViewsDisplayed()
        {
            try
            {
                return numberOfLikes.Displayed
                && numberOfViews.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
