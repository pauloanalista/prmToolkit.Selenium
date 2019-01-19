using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;


namespace prmToolkit.Selenium
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            //webDriver.Manage().Timeouts().SetPageLoadTimeout(timeToWait);
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            if (!(webDriver is InternetExplorerDriver))
                webElement.Submit();
            else
                webElement.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Retorna o elemento pesquisado, caso não encontre, retorna o valor nulo.
        /// </summary>
        public static IWebElement FindElementOrDefault(this IWebDriver webDriver, By by)
        {
            try
            {
                return webDriver.FindElement(by);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Verifica se o elemento foi encontrado
        /// </summary>
        public static bool HasElement(this IWebDriver webDriver, By by)
        {
            try
            {
                var element = webDriver.FindElement(by);
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}