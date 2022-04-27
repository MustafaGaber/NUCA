using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NUCA.Projects.Domain.Entities.Invoices
{
    public class InvoiceSection : Entity
    {
        private readonly List<InvoiceItem> _items = new List<InvoiceItem>();
        public string Name { get; private set; }
        public virtual IReadOnlyList<InvoiceItem> Items => _items.ToList();
        public long UserId { get; private set; }
        protected InvoiceSection() { }
        public InvoiceSection(Section boqSection, int count)
        {
            Name = boqSection.Name;
            _items = boqSection.Items.Select(item => new InvoiceItem(
                item.Id,
                item.Index,
                item.Content,
                item.Unit,
                item.Quantity * count,
                item.UnitPrice,
                0,
                0,
                new List<InvoiceItemPercentage>(),
                "",
                null)
            ).ToList();
        }
        public InvoiceSection(Section boqSection, InvoiceSection previousSection, int count)
        {
            Name = boqSection.Name;
            _items = boqSection.Items.Select(item =>
            {
                var previousItem = previousSection._items.First(i => i.Id == item.Id);
                return new InvoiceItem(
                item.Id,
                item.Index,
                item.Content,
                item.Unit,
                item.Quantity * count,
                item.UnitPrice,
                previousItem.TotalQuantity,
                0,
                previousItem.Percentages.ToList(),
                previousItem.Notes,
                previousItem.UserId);
            }).ToList();
        }
        public void UpdateItem(long itemId, InvoiceItemUpdates updates)
        {
            InvoiceItem item = _items.First(i => i.Id == itemId);
            item.Update(updates);
        }
        /*public void UpdateCurrentQuantity(long itemId, double quantity, string userId)
        {
            InvoiceItem item = _items.First(i => i.Id == itemId);
            item.UpdateCurrentQuantity(quantity, userId);
        }
        public void UpdatePercentages(long itemId, List<InvoiceItemPercentage> percentages, string userId)
        {
            InvoiceItem item = _items.First(i => i.Id == itemId);
            item.UpdatePercentages(percentages, userId);
        }
        public void UpdateNotes(long itemId, string notes, string userId)
        {
            InvoiceItem item = _items.First(i => i.Id == itemId);
            item.UpdateNotes(notes, userId);
        }*/
    }
}
