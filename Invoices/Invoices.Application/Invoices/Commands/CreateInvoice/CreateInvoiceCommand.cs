using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;
using NUCA.Invoices.Domain.Entities.Invoices;
using System;

namespace NUCA.Invoices.Application.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : ICreateInvoiceCommand
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IBoqRepository _boqRepository;
        public CreateInvoiceCommand(IInvoiceRepository invoiceRepository, IBoqRepository boqRepository)
        {
            _invoiceRepository = invoiceRepository;
            _boqRepository = boqRepository;
        }
        public Invoice Execute(long projectId, long userId, bool isFinal)
        {
            Boq boq = _boqRepository.Get(projectId);
            return new Invoice(projectId, boq, isFinal);
        }
    }
}
