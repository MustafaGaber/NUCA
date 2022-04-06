using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Invoices;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Invoices.Commands.UpdateItems
{
    public class UpdateItemsCommand : IUpdateItemsCommand
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public UpdateItemsCommand(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public Invoice Execute(long id, List<UpdateItemModel> updates, long userId)
        {
            Invoice invoice = _invoiceRepository.Get(id);
            updates.ForEach(update => invoice.UpdateItem(
                update.TableId,
                update.SectionId,
                update.ItemId,
                new InvoiceItemUpdates(
                    update.CurrentQuantity,
                    update.Percentages.Select(u => new InvoiceItemPercentage(u.Quantity, u.Percentage, u.Notes)).ToList(),
                    update.Notes,
                    userId
                    ),
                update.IsSupplies
                ));
            _invoiceRepository.Update(invoice);
            return invoice;
        }
    }
}
