using Ardalis.GuardClauses;
using NUCA.Invoices.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NUCA.Invoices.Domain.Entities.Invoices
{
    public class InvoiceItem: Entity
    {
        private List<InvoiceItemPercentage> _percentages = new List<InvoiceItemPercentage>();
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        public double PreviousQuantity { get; private set; }
        public double CurrentQuantity { get; private set; }
        public double TotalQuantity => PreviousQuantity + CurrentQuantity;
        public virtual IReadOnlyList<InvoiceItemPercentage> Percentages => _percentages.ToList();
        public string Notes { get; private set; }
        public long? UserId { get; private set; }
        protected InvoiceItem() { }
        public InvoiceItem(long id, string index, string content, string unit, double quantity, double unitPrice, double previousQuantity, double currentQuantity, List<InvoiceItemPercentage> percentages, string notes, long? userId)
        {
            Id = id;
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            PreviousQuantity = Guard.Against.Negative(previousQuantity, nameof(previousQuantity));
            CurrentQuantity = currentQuantity;
            _percentages = percentages;
            Notes = notes;
            UserId = userId;
            ValidatePercentages();
        }
        public void Update(InvoiceItemUpdates updates)
        {
            CurrentQuantity = updates.CurrentQuantity;
            _percentages = updates.Percentages;
            Notes = updates.Notes;
            UserId = updates.UserId;
            ValidatePercentages();
        }

        private void ValidatePercentages()
        {
            if (TotalQuantity != Percentages.Sum(p => p.Quantity))
            {
                throw  new ArgumentException("Not valid percentages");
            }
        }
       /* public void UpdateCurrentQuantity(double quantity, string userId) {
            CurrentQuantity = quantity;
            UserId = userId;
        }
        public void UpdatePercentages(List<InvoiceItemPercentage> percentages, string userId)
        {
            _percentages = percentages;
            UserId = userId;
        }
        public void UpdateNotes(string notes, string userId)
        {
            Notes = notes;
            UserId = userId;
        }*/
    }
}
