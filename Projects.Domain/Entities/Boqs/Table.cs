using Ardalis.GuardClauses;
using NUCA.Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Table : Entity
    {
        private readonly List<Section> _sections = new List<Section>();
        public string Name { get; private set; }
        public int Count { get; private set; }
        public double Addition { get; private set; }
        public virtual IReadOnlyList<Section> Sections => _sections.ToList();
        protected Table() { }
        public Table(string name, int count, double addition)
        {
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count)); 
            Addition = Guard.Against.OutOfRange(addition, nameof(addition), -1, double.MaxValue);
        }
        internal void UpdateTable(string name, int count, double addition)
        {
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count));
            Addition = Guard.Against.OutOfRange(addition, nameof(addition), -1, double.MaxValue);
        }
        internal void AddSection(string sectionName)
        {
            _sections.Add(new Section(sectionName));
        }
        internal void UpdateSection(long id, string sectionName)
        {
            Section section = _sections.Find(s => s.Id == id);
            section.UpdateName(sectionName);
        }
        internal void DeleteSection(long id)
        {
            Section section = _sections.Find(s => s.Id == id);
            if (section != null)
            {
                _sections.Remove(section);
            }
        }
        internal void AddItem(long sectionId, string index, string content, string unit, double quantity, double unitPrice)
        {
            Section section = _sections.Find(s => s.Id == sectionId);
            section.AddItem(index, content, unit, quantity, unitPrice);
        }
        internal void UpdateItem(long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice)
        {
            Section section = _sections.Find(s => s.Id == sectionId);
            section.UpdateItem(itemId, index, content, unit, quantity, unitPrice);
        }
        internal void DeleteItem(long sectionId, long itemId)
        {
            Section section = _sections.Find(s => s.Id == sectionId);
            section.DeleteItem(itemId);
        }
    }
}
