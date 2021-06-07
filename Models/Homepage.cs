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
    public static class Homepage
    {
        public static string PartialXPath;
        public static IWebLocator Input_SearchBox => L("Search Bar",By.Id("twotabsearchtextbox"));
        public static By Input_SearchBox_BY => By.Id("twotabsearchtextbox");
        public static IWebLocator Btn_Search => L("Search Button", By.Id("nav-search-submit-button"));
        public static IWebLocator DeliverTo => L("Deliver To Location", By.Id("nav-global-location-popover-link"));
        public static IWebLocator ChooseLocation => L("Choose Your Location Popup", By.XPath("//header/h4[text()='Choose your location']"));
        public static IWebLocator Input_Location => L("Location Input", By.Id("GLUXZipUpdateInput"));
        public static IWebLocator Btn_Apply => L("Location Input", By.XPath("//span[text()='Apply']/preceding::input[1]"));

        public static IWebLocator DeliverToValue => L("Deliver to Value", By.XPath("//span[contains(text(),'Deliver to')]/parent::div/span[contains(text(),'"+PartialXPath+"')]"));
    }
}
