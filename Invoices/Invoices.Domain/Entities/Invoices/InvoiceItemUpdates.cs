


using System.Collections.Generic;

namespace NUCA.Invoices.Domain.Entities.Invoices
{
    public class InvoiceItemUpdates
    {
        public double CurrentQuantity { get; private set; }
        public List<InvoiceItemPercentage> Percentages { get; private set; } = new List<InvoiceItemPercentage>();
        public string Notes { get; private set; }
        public long UserId { get; private set; }
        public InvoiceItemUpdates(double currentQuantity, List<InvoiceItemPercentage> percentages, string notes, long userId)
        {
            CurrentQuantity = currentQuantity;
            Percentages = percentages;
            Notes = notes;
            UserId = userId;
        }
    }
}