using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TAF_ScreenplayPattern;
using TAF_ScreenplayPattern.Z_Util;
using TAF_ScreenplayPattern.Models;
using FluentAssertions;
using TAF_ScreenplayPattern.Tasks;

namespace TAF_ScreenPlayPattern.Tests
{
    [TestFixture]
    public class UI_Tests : NunitCore
    {
        IWebDriver driver = null;
        string strBrowser = Env.Browser;


        [Test]
        public void ValidateHomeSearch()
        {
            IActor user = new Actor(name: "TestUser_1", logger: new ConsoleLogger());
            string ProducName = "Apple Ipad Pro";
            try
            {
                // can be overriden for specific cases
                string strLocalBrowser = "Firefox";
                if (strLocalBrowser != null)
                {
                    driver = BaseWebDriver.SetupWebDriver(strLocalBrowser);
                    Console.WriteLine("");
                    Console.WriteLine("BROWSER OVERRIDDEN : " + strLocalBrowser);
                    Console.WriteLine("");
                }
                else
                {
                    driver = BaseWebDriver.SetupWebDriver(strBrowser);
                }

                user.Can(BrowseTheWeb.With(driver));

                user.AttemptsTo(Navigate.ToUrl(Env.url));

                Thread.Sleep(1500);

                user.AskingFor(ValueAttribute.Of(Homepage.Input_SearchBox)).Should().BeEmpty();

                user.AttemptsTo(SearchAmazon.For(ProducName));

                Thread.Sleep(2000);

                Resultpage.PartialXpath = ProducName;

                user.AskingFor(Appearance.Of(Resultpage.ResultLinks)).Should().BeTrue();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if(driver != null)
                {
                    user.AttemptsTo(QuitWebDriver.ForBrowser());
                }
            }
        }

        [Test]
        public void AddLocation()
        {
            IActor user = new Actor(name: "TestUser_1", logger: new ConsoleLogger());
            string PinCode = "411038";

            try
            {
                string strLocalBrowser = null;

                if(strLocalBrowser != null)
                {
                    driver = BaseWebDriver.SetupWebDriver(strLocalBrowser);
                    Console.WriteLine("");
                    Console.WriteLine("BROWSER OVERRIDDEN : " + strLocalBrowser);
                    Console.WriteLine("");
                }
                else
                {
                    driver = BaseWebDriver.SetupWebDriver(strBrowser);
                }

                user.Can(BrowseTheWeb.With(driver));

                user.AttemptsTo(Navigate.ToUrl(Env.url));

                user.AskingFor(Appearance.Of(Homepage.DeliverTo)).Should().BeTrue();
                
                user.AttemptsTo(SelectLocation.For(PinCode));

                Thread.Sleep(2000);
                Homepage.PartialXPath = "Pune " + PinCode;
                user.AskingFor(Appearance.Of(Homepage.DeliverToValue)).Should().BeTrue();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (driver != null)
                {
                    user.AttemptsTo(QuitWebDriver.ForBrowser());
                }
            }

        }
    }
}
