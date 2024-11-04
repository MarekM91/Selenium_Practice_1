using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Practice_1
{
    public class Tests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewPaste()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            try
            {
                driver.Navigate().GoToUrl("https://pastebin.com/");
                
                IWebElement cookiesButton = driver.FindElement(By.XPath("//button[span[text()='AGREE']]"));
                cookiesButton.Click();

                IWebElement newPasteField = driver.FindElement(By.Id("postform-text"));
                newPasteField.Click();
                newPasteField.SendKeys("Hello from WebDriver");

                IWebElement pasteExpirationField = driver.FindElement(By.Id("select2-postform-expiration-container"));
                pasteExpirationField.Click();

                IWebElement highlightedExpirationOption = driver.FindElement(By.XPath("//li[contains(@class, 'select2-results__option') and text()='10 Minutes']"));
                highlightedExpirationOption.Click();

                IWebElement pasteName = driver.FindElement(By.Id("postform-name"));
                pasteName.Click();
                pasteName.SendKeys("helloweb");

                IWebElement savePaste = driver.FindElement(By.XPath("//button[text()='Create New Paste']"));
                savePaste.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}