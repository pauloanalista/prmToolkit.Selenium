using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using prmToolkit.Selenium.Enum;
using System;

namespace prmToolkit.Selenium
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver = null, bool executeInBackground = false, bool hideCommandPromptWindow = false)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:

                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService(pathDriver);
                    firefoxDriverService.HideCommandPromptWindow = hideCommandPromptWindow;

                    FirefoxOptions optionsFF = new FirefoxOptions();
                    if (executeInBackground)
                    {
                        optionsFF.AddArgument("--headless");
                    }

                    webDriver = new FirefoxDriver(firefoxDriverService, optionsFF, TimeSpan.FromSeconds(10));

                    break;
                case Browser.Chrome:

                    
                    var chromeDriverService = ChromeDriverService.CreateDefaultService(pathDriver);
                    chromeDriverService.HideCommandPromptWindow = hideCommandPromptWindow;

                    ChromeOptions optionsC = new ChromeOptions();
                    if (executeInBackground)
                    {
                        optionsC.AddArgument("--headless");
                    }

                    webDriver = new ChromeDriver(chromeDriverService, optionsC);

                    break;
            }

            return webDriver;
        }
    }
}