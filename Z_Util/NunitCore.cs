using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_ScreenplayPattern.Z_Util
{
    public class NunitCore
    {
        public static string Status = null;
        StreamWriter writer = null;
        public string TempReportLocation = Directory.GetCurrentDirectory() + @"\ReportLog\Report_Temp.txt";



        //Runs before each test
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Test Started :: " + TestContext.CurrentContext.Test.Name);
            Console.WriteLine("");

        }

        //Runs after each test
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("");
            switch (TestContext.CurrentContext.Result.Outcome.Status.ToString())
            {
                case "Passed":
                    Console.WriteLine("Test Status :: PASS");
                    break;
                case "Failed":
                    Console.WriteLine("Test Status :: FAIL");
                    break;
                case "Skipped":
                    Console.WriteLine("Test Status :: SKIPPED");
                    break;
                case "Inconclusive":
                    Console.WriteLine("Test Status :: INCONCLUSIVE");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
        }

        // executed once at startup
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            writer = new StreamWriter(TempReportLocation);
            Console.SetOut(writer);
            Console.WriteLine("~~ Env Config ~~");
            Console.WriteLine("Project : "+Env.ProjectName);
            Console.WriteLine("URL : "+Env.url);
            Console.WriteLine("Browser : "+Env.Browser);
            Console.WriteLine("");
        }

        // executed once at end
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            writer.Close();
            string NewFileName = Directory.GetCurrentDirectory() + @"\ReportLog\Report_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".txt";
            System.IO.File.Move(TempReportLocation, NewFileName);
            Process.Start(NewFileName);
        }
    }
}
