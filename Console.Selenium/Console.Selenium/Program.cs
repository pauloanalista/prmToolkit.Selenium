using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Console.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\_Paulo\POCs\Selenium\driver");

            webDriver.LoadPage(TimeSpan.FromSeconds(10), @"https://www.google.com");

            webDriver.SetText(By.Name("q"), "ilovecode.com.br");
            webDriver.Submit(By.Name("btnK"));

            Thread.Sleep(20000);

            webDriver.Close();



        }
    }
}
