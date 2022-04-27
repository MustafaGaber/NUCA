using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Invoices.States
{
    public class PublishedState : InvoiceState
    {
        public PublishedState(Invoice invoice) : base(invoice)
        {
        }

        public override void Back()
        {
            
        }

        public override void Next()
        {
            
        }
    }
}
