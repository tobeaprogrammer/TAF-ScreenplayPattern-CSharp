using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_ScreenplayPattern.Z_Util
{
    public class BaseWebDriver
    {
        public static IWebDriver SetupWebDriver(string BrowserName)
        {
            try
            {
                IWebDriver driver = null;
                var ExplicitWait = TimeSpan.FromSeconds(int.Parse(Env.ExplicitWait_Time));
                var PageLoadWait = TimeSpan.FromSeconds(int.Parse(Env.PageLoadWait_Time)); 
                switch (BrowserName)
                {
                    case "Chrome":
                        var chromeservice = ChromeDriverService.CreateDefaultService();
                        chromeservice.HideCommandPromptWindow = true;
                        var ChromeOptions = new ChromeOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal,
                        };
                        driver = new ChromeDriver(chromeservice, ChromeOptions, ExplicitWait);
                        break;

                    case "Firefox":
                        var firefoxservice = FirefoxDriverService.CreateDefaultService();
                        firefoxservice.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                        firefoxservice.HideCommandPromptWindow = true;

                        var firefoxOptions = new FirefoxOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal,
                            AcceptInsecureCertificates = true,
                        };
                        driver = new FirefoxDriver(firefoxservice, firefoxOptions, ExplicitWait);
                        break;
                }
                driver.Manage().Timeouts().PageLoad = PageLoadWait;
                driver.Manage().Window.Maximize();
                driver.Manage().Cookies.DeleteAllCookies();
                driver.SwitchTo().ActiveElement();

                return driver;
            }
            catch (Exception)
            {
                throw new Exception("Browser Setup Failed");
            }
        }
    }
}
