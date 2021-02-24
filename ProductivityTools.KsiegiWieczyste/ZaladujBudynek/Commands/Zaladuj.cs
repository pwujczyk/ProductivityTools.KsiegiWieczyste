using ProductivityTools.KsiegiWieczyste.App;
using ProductivityTools.KsiegiWieczyste.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.KsiegiWieczyste.ZaladujBudynek.Commands
{

    public class Zaladuj : PSCmdlet.PSCommandPT<ZaladujBudynekCmdlet>
    {
        public Zaladuj(ZaladujBudynekCmdlet cmdletType) : base(cmdletType) { }

        protected override bool Condition => true;

        protected override void Invoke()
        {
            Class1 c = new Class1();
            c.OtworzKsiege("WA1M", "00549771", "9");
            Console.WriteLine("Hello from zalduj budynek");
        }
    }
}
