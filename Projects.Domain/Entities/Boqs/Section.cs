using NUCA.Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Section: Entity
    {
        private readonly List<Item> _items = new List<Item>();
        public string Name { get; private set; }
        public virtual IReadOnlyList<Item> Items => _items.ToList();
        protected Section() { }
        public Section(string name)
        {
            Name = name;
        }
        internal void UpdateName(string newName)
        {
            Name = newName;
        }
        internal void AddItem(string index, string content, string unit, double quantity, double unitPrice)
        {
            _items.Add(new Item(index, content, unit, quantity, unitPrice));
        }
        internal void UpdateItem(long id, string index, string content, string unit, double quantity, double unitPrice)
        {
            Item item = _items.First(t => t.Id == id);
            item.UpdateItem(index, content, unit, quantity, unitPrice);
        }
        internal void DeleteItem(long id)
        {
            Item item = _items.Find(s => s.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}
