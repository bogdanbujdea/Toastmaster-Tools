using System;
using System.Collections.Generic;
using ToastmasterTools.UnitTests.Features;

namespace ToastmasterTools.Core.Features.AHCounter
{
    public class AHCounter
    {
        public Dictionary<Mistake, int> Mistakes { get; set; }

        public AHCounter()
        {
            Reset();
        }

        public int AddMistake(Mistake mistake)
        {
            return ++Mistakes[mistake];
        }

        public void Reset()
        {
            Mistakes = new Dictionary<Mistake, int>();
            foreach (var name in Enum.GetValues(typeof(Mistake)))
            {
                Mistakes[(Mistake)name] = 0;
            }
        }
    }
}