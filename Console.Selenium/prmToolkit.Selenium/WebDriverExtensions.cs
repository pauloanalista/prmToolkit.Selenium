using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;


namespace prmToolkit.Selenium
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static void LoadPage(this IWebDriver webDriver, string url, int timeToWaitInSeconds = 40)
        {
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeToWaitInSeconds);
            
            webDriver.Navigate().GoToUrl(url);
        }

        public static void LoadPage(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver, By by, string text)
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

        /// <summary>
        /// Retorna o elemento informado. Este método faz uma tentativa a cada 1 segundo respeitando o limite de tempo informado no parametro waitLimitInSeconds.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="by"></param>
        /// <param name="waitLimitInSeconds"></param>
        /// <returns></returns>
        public static IWebElement WaitFindElement(this IWebDriver webDriver, By by, int waitLimitInSeconds = 10)
        {
            IWebElement webElement = null;

            for (int i = 1; i <= waitLimitInSeconds; i++)
            {
                try
                {
                    return webDriver.FindElement(by);
                }
                catch
                {

                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return webElement;
        }

        public static object ExecuteJavaScript(this IWebDriver driver, string scriptJs, params object[] args)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(scriptJs, args);

        }

        public static void Click(this IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by).Click();
            }
            catch
            {
                
            }
        }

        public static void Clear(this IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by).Clear();
            }
            catch
            {

            }
        }

        public static void SendKeys(this IWebDriver webDriver, By by, string text)
        {
            try
            {
                webDriver.FindElement(by).SendKeys(text);
            }
            catch
            {

            }
        }
    }
}