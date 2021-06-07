using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_ScreenplayPattern
{
    public static class Env
    {

        // Project Details
        public static string ProjectName = "Amazon IN";
        public static string url = "https://www.amazon.in/";

        // Browser Details
        //Browser Values : Chrome, Firefox
        public static string Browser = "Chrome";

        // Waits : In Seconds
        public static string ExplicitWait_Time = "60";
        public static string Interval_Time ="2" ;
        public static string ExplicitElementWait_Time = "60";
        public static string PageLoadWait_Time = "60";
    }
}
