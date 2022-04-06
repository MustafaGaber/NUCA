using Ardalis.GuardClauses;
using NUCA.Common.DDD;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Boq : AggregateRoot
    {
        private readonly List<Table> _tables = new List<Table>();
       // public long ProjectId { get; private set; }
        public double Addition { get; private set; }
        public virtual IReadOnlyList<Table> Tables => _tables.ToList();
        protected Boq() { }
        public Boq(long id, double addition)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Addition = Guard.Against.OutOfRange(addition, nameof(addition), -1 , double.MaxValue);
        }
        public void UpdateBoq(double addition)
        {
            Addition = Guard.Against.OutOfRange(addition, nameof(addition), -1, double.MaxValue); ;
        }
        public void AddTable(string name, int count, double addition)
        {
            Guard.Against.NegativeOrZero(count, nameof(count));
            Guard.Against.OutOfRange(addition, nameof(addition), -1, double.MaxValue);
            Table table = new Table(name, count, addition);
            _tables.Add(table);
        }
        public void UpdateTable(long id, string name, int count, double addition)
        {
            Guard.Against.OutOfRange(addition, nameof(addition), -1, double.MaxValue);
            Table table = _tables.First(t => t.Id == id);
            table.UpdateTable(name, count, addition);
        }

        public void DeleteTable(long id)
        {
            Table table = _tables.Find(t => t.Id == id);
            if (table != null)
            {
                _tables.Remove(table);
            }
        }
        public void AddSection(long tableId, string sectionName)
        {
            Table table = _tables.First(t => t.Id == tableId);
            table.AddSection(sectionName);
        }
        public void UpdateSection(long tableId, long sectionId, string sectionName)
        {
            Table table = _tables.First(t => t.Id == tableId);
            table.UpdateSection(sectionId, sectionName);
        }
        public void DeleteSection(long tableId, long sectionId)
        {
            Table table = _tables.First(t => t.Id == tableId);
            table.DeleteSection(sectionId);
        }
        public void AddItem(long tableId, long sectionId, string index, string content, string unit, double quantity, double unitPrice)
        {
            Table table = _tables.First(t => t.Id == tableId);
            table.AddItem(sectionId, index, content, unit, quantity, unitPrice);
        }
        public void UpdateItem(long tableId, long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice)
        {
            Table table = _tables.First(t => t.Id == tableId);
            table.UpdateItem(sectionId, itemId, index, content, unit, quantity, unitPrice);
        }
        public void DeleteItem(long tableId, long sectionId, long itemId) {
            Table table = _tables.First(t => t.Id == tableId);
            table.DeleteItem(sectionId, itemId);
        }

    }
}
