using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_ScreenplayPattern.Models;

namespace TAF_ScreenplayPattern.Tasks
{
    class SelectLocation : ITask
    {
        public string PinCode { get; }

        private SelectLocation(string phrase) => PinCode = phrase;

        public static SelectLocation For(String PinCode) => new SelectLocation(PinCode);
        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(Homepage.DeliverTo));

            actor.AskingFor(Appearance.Of(Homepage.ChooseLocation)).Should().BeTrue();

            actor.AttemptsTo(SendKeys.To(Homepage.Input_Location, PinCode));

            actor.AttemptsTo(Click.On(Homepage.Btn_Apply));
        }
    }
}
