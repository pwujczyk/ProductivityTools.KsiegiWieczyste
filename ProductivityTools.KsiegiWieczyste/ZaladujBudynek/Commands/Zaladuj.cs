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
            Console.WriteLine("Hello from zalduj budynek");
        }
    }
}
