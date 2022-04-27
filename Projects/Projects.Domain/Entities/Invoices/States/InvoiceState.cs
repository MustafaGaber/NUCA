using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Invoices.States
{
    public abstract class InvoiceState
    {
        protected Invoice invoice;

        public InvoiceState(Invoice invoice)
        {
            this.invoice = invoice;
        }

        public abstract void Next();

        public abstract void Back();
    }
}
