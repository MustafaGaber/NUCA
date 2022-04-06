using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Domain.Entities.Invoices.States
{
    public class ExecutionState : InvoiceState
    {
        public ExecutionState(Invoice invoice): base(invoice) { }
        public override void Back()
        {
            
        }

        public override void Next()
        {
            // invoice.SetState(new TechnicalOfficeState(invoice));
        }
    }
}
