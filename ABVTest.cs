using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTest
{
    public class ABVTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            var options = new ChromeOptions();

            this.driver = new ChromeDriver(options);
            driver.Url = "https://www.abv.bg/";
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        [Test]

        public void Test_AssertMainPageTitle()
        {
            driver.Url = "https://www.abv.bg/";

            string expectTitle = "АБВ Поща";
        }
        [Test]
        public void Test_AssertRegistration()
        {
            var RegistrationElement = driver.FindElement(By.CssSelector("body > header > div.fr > menu > div > a:nth-child(2)"));

            string expectedTitle = "Регистрация в АБВ";

            Assert.AreEqual(expectedTitle, RegistrationElement.Text);

        }
        
        [Test]
        public void Test_LoginInvalidUresnameAndPassword()
        {
            driver.Navigate().GoToUrl("https://www.abv.bg/");

            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("asdfghj");

            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("12453");

            driver.FindElement(By.Id("loginBut")).Click();
            driver.FindElement(By.Id("form")).Click();

            Assert.That(driver.FindElement(By.Id("form.errors")).Text, Is.EqualTo("Грешен потребител / парола."));
            driver.Close();


        }

    }
}