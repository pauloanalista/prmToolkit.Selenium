using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console.Selenium.FullFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, AppDomain.CurrentDomain.BaseDirectory, false, true);

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
