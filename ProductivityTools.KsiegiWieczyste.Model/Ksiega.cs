using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.KsiegiWieczyste.Model
{
    public class Ksiega
    {
        public Dzial1 Dzial1 { get; set; }
        public List<Dzial2> Dzial2 { get; set; }
        public Dzial4 Dzial4 { get; set; }

        public Ksiega()
        {
            this.Dzial2 = new List<Dzial2>();
        }
    }
}
