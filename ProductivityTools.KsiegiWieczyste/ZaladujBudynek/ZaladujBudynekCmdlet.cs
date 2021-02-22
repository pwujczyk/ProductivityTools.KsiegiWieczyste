using ProductivityTools.KsiegiWieczyste.ZaladujBudynek.Commands;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.KsiegiWieczyste.NewFolder
{
    [Cmdlet("Zaladuj", "Budynek")]
    public class ZaladujBudynekCmdlet : PSCmdlet.PSCmdletPT
    {
        public ZaladujBudynekCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            this.AddCommand(new Zaladuj(this));
            this.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
