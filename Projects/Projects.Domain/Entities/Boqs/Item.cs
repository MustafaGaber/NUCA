using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Item: Entity
    {
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        protected Item() { }
        public Item(string index, string content, string unit, double quantity, double unitPrice)
        {
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice)); 
        }
        internal void UpdateItem(string index, string content, string unit, double quantity, double unitPrice)
        {
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
        }
    }
}
