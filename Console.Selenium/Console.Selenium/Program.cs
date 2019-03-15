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
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\Users\Paulo\Documents\GitHub\prmToolkit.Selenium\Driver", true, true);

            webDriver.LoadPage(TimeSpan.FromSeconds(10), @"https://www.google.com");

            webDriver.SetText(By.Name("q"), "ilovecode.com.br");
            webDriver.Submit(By.Name("btnK"));

            webDriver.WaitFindElement(By.Id("teste"));

            //webDriver.SendKeys(By.Id(""), Keys.End);
            
            Thread.Sleep(20000);

            webDriver.Close();



        }
    }
}
