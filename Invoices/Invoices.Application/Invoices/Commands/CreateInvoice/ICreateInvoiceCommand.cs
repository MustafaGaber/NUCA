
using NUCA.Invoices.Domain.Entities.Invoices;

namespace NUCA.Invoices.Application.Invoices.Commands.CreateInvoice
{
    public interface ICreateInvoiceCommand
    {
        public Invoice Execute(long projectId, long userId, bool isFinal);
    }
}
