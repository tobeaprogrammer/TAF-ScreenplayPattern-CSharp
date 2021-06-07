using Boa.Constrictor.WebDriver;
using static Boa.Constrictor.WebDriver.WebLocator;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_ScreenplayPattern.Models
{
    public static class Resultpage
    {
        public static string PartialXpath = null;
        public static IWebLocator ResultLinks =>L("Amazon Results Page",By.XPath("//span[contains(text(),'results for')]/parent::div[1]/span[contains(text(),'"+ PartialXpath + "')]"));
    }
}
