using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Invoices.States
{
    public class TechnicalOfficeState : InvoiceState
    {
        public TechnicalOfficeState(Invoice invoice) : base(invoice)
        {
        }

        public override void Back()
        {
            //invoice.SetState(new ExecutionState(invoice));
        }

        public override void Next()
        {
           // invoice.SetState(new RevisionState(invoice));
        }
    }
}
