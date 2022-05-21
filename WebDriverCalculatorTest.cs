
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {
        private ChromeDriver driver;
       
        IWebElement firstNum1;
        IWebElement operation;
        IWebElement secontNum2;
        IWebElement calculate;
        IWebElement reset;
        IWebElement resultFind;
       

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
             this.driver = new ChromeDriver();
            
            driver.Url = "https://number-calculator.nakov.repl.co/";
            firstNum1 = driver.FindElement(By.Id("number1"));
            operation = driver.FindElement(By.Id("operation"));
            secontNum2 = driver.FindElement(By.Id("number2"));
            calculate = driver.FindElement(By.Id("calcButton"));
            reset = driver.FindElement(By.Id("resetButton"));
            resultFind = driver.FindElement(By.Id("result"));
           
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [TestCase("7", "9", "+", "Result: 16")]
        [TestCase("28", "8", "-", "Result: 20")]
        [TestCase("6", "6", "*", "Result: 36")]
        [TestCase("28", "2", "/", "Result: 14")]
        [TestCase("bslar", "bslaraa", "-", "Result: invalid input")]
        [TestCase("11", "ayy", "+", "Result: invalid input")]
        public void Test_Calculator(string num1, string num2, string operato, string result)
        {

            firstNum1.SendKeys(num1);
            operation.SendKeys(operato);
            secontNum2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultFind.Text));
           

            reset.Click();

        }
    }
}