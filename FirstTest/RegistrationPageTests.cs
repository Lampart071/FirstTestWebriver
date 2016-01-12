using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FirstTest
{
    [TestFixture]
    class RegistrationPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Login()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            //options.AddArgument("--incognito");
            //options.AddArgument("--disable-extensions");
            //options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://www.qa.way2automation.com");
            driver.FindElement(By.CssSelector("#load_form > h3"));
            driver.FindElement(By.CssSelector("#load_form > div > div.span_3_of_4 > p > a[href='#login']")).Click();
            driver.FindElement(By.CssSelector("#load_form > fieldset:nth-child(5) > input[name='username']")).SendKeys("j2bwebdriver");
            driver.FindElement(By.CssSelector("#load_form > fieldset:nth-child(6) > input[name='password']")).SendKeys("j2bwebdriver");
            driver.FindElements(By.CssSelector("#load_form > div > div.span_1_of_4 > input"))[1].Submit();
            Thread.Sleep(1000);
        }
        
        [Test]
        public void RegistrationPageOpens()
        {
            driver.Navigate().GoToUrl("http://way2automation.com/way2auto_jquery/registration.php");
            Assert.IsTrue(driver.FindElement(By.CssSelector("#wrapper > div > div > h1")).Text.Contains("Registration"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("#wrapper > div > div > div > h2")).Text.Contains("Registration Form"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
