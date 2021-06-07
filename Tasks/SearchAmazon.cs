using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_ScreenplayPattern.Models;

namespace TAF_ScreenplayPattern.Tasks
{
    class SearchAmazon : ITask
    {
        public string Phrase { get; }

        private SearchAmazon(string phrase) => Phrase = phrase;

        public static SearchAmazon For(String phrase) => new SearchAmazon(phrase);
        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(SendKeys.To(Homepage.Input_SearchBox, Phrase));
            
            actor.AttemptsTo(Click.On(Homepage.Btn_Search));
        }
    }
}
