using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Invoices
{
    public class InvoiceItemPercentage : Entity
    {
        public double Quantity { get; private set; }
        public double Percentage { get; private set; }
        public string Notes { get; private set; }

        public InvoiceItemPercentage(double quantity, double percentage, string notes)
        {
            Quantity = quantity;
            if (percentage < 0)
            {
                Percentage = 0;
            }
            else if (percentage > 100)
            {
                Percentage = 100;
            }
            else
            {
                Percentage = percentage;
            }
            Notes = notes;
        }
    }
}
