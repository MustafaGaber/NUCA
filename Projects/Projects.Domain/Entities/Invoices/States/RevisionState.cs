using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Invoices.States
{
    public class RevisionState : InvoiceState
    {
        public RevisionState(Invoice invoice) : base(invoice)
        {
        }

        public override void Back()
        {
           // invoice.SetState(new TechnicalOfficeState(invoice));
        }

        public override void Next()
        {
            //invoice.SetState(new PublishedState(invoice));
        }
    }
}
