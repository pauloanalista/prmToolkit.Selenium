using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using prmToolkit.Selenium.Enum;

namespace prmToolkit.Selenium
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(
            Browser browser, string pathDriver = null, bool executeInBackground = false )
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:

                    if (executeInBackground)
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArgument("--headless");
                        webDriver = new FirefoxDriver(pathDriver, options);
                    }
                    else
                    {
                        webDriver = new FirefoxDriver(pathDriver);
                    }

                    
                    break;
                case Browser.Chrome:

                    if (executeInBackground)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        webDriver = new ChromeDriver(pathDriver, options);
                    }
                    else
                    {
                        webDriver = new ChromeDriver(pathDriver);
                    }

                    
                    break;
            }

            return webDriver;
        }
    }
}