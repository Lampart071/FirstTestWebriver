using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FirstTest
{
    [TestFixture]
    public class GoogleTests
    {
        [Test]
        public void TestThatGoogleFindsCheeseNotBacon()
        {
            // Setup ChromeDriver configuration
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            // Choose page link
            driver.Navigate().GoToUrl("http://google.com");
            // Setup ChromeDriver configuration
            driver.FindElement(By.Id("lst-ib")).SendKeys("Cheese");
            driver.FindElement(By.Name("btnK")).Submit();
            // Wait for webelements to load
            Thread.Sleep(1000);
            // Assertion on first search result position		
            Assert.IsTrue(driver.FindElement(By.CssSelector("#rso > div > div:nth-child(1) > div > h3 > a")).Text.Contains("Cheese"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("#rso > div > div:nth-child(1) > div > h3 > a")).Text.Contains("Wikipedia"));
            Assert.IsFalse(driver.FindElement(By.CssSelector("#rso > div > div:nth-child(1) > div > h3 > a")).Text.Contains("Bacon"));
            // Closing browser window
            driver.Close();
        }

        [Test]
        public void TestThatGoogleFindsVegetablesNotMeat()
        {
        }
        [Test]
        public void TestThatGoogleFindsMushroomsNotFlowers()
        {
        }
        [Test]
        public void TestThatGoogleFindsJavaNotCsharp()
        {
        }
    }
}
