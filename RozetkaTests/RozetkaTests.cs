using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace RozetkaTests
{
    public class RozetkaTests : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public RozetkaTests()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Assert that product categories are displayed on the homepage
        [Fact]
        public void Categories_ShouldBeDisplayed()
        {
            driver.Navigate().GoToUrl(
                "https://rozetka.com.ua/"
            );

            var products = wait.Until(d =>
                d.FindElements(By.CssSelector(
                    "a.category-link"))
            );

            Assert.NotEmpty(products);
        }

        // Assert that social links redirect to expected websites
        [Fact]
        public void SocialLinks_ShouldRedirectToWebsites()
        {
            driver.Navigate().GoToUrl(
                "https://rozetka.com.ua/"
            );

            var links = wait.Until(d =>
                d.FindElements(By.CssSelector(
                    "a.social-link"))
            );

            Assert.NotEmpty(links);

            string expectedUrl = "https://www.tiktok.com/@rozetkaua";

            links[0].Click();
            wait.Until(d => d.WindowHandles.Count > 1);

            _ = driver.SwitchTo().Window(driver.WindowHandles[^1]);
            Assert.Equal(expectedUrl, driver.Url);
        }

        // Assert that the category contains expected fields
        [Fact]
        public void Category_ShouldContainExpectedFields()
        {
            driver.Navigate().GoToUrl(
                "https://rozetka.com.ua/"
            );

            var catalogButton = wait.Until(d => d.FindElement(By.CssSelector("button[data-testid='fat_menu_btn']")));
            catalogButton.Click();

            var forGamersCategory = wait.Until(d =>
            d.FindElement(By.CssSelector("ul.list > li[data-index='3']")));

            new Actions(driver).MoveToElement(forGamersCategory).Perform();

            var list = driver.FindElement(By.CssSelector("ul.list-content"));
            Assert.Contains("Ігрові", list.Text);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }

}
