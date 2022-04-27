
using NUCA.Projects.Domain.Entities.Invoices;

namespace NUCA.Projects.Application.Invoices.Commands.CreateInvoice
{
    public interface ICreateInvoiceCommand
    {
        public Invoice Execute(long projectId, long userId, bool isFinal);
    }
}
