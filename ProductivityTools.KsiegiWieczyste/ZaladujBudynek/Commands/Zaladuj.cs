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
            Application c = new Application();
            c.OtworzKsiege("WA1M", "00550063", "3");
            c.ZaldujKsiegeDoBazy("00550063");
            Console.WriteLine("Hello from zalduj budynek");
        }
    }
}
