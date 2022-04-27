using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Domain.Entities.Invoices
{
    public abstract class InvoiceTable : Entity
    {
        public long InvoiceId { get; private set; }
        private readonly List<InvoiceSection> _sections = new List<InvoiceSection>();
        public string Name { get; private set; }
        public double Addition { get; private set; }
        public virtual IReadOnlyList<InvoiceSection> Sections => _sections.ToList();
        protected InvoiceTable() { }
        public InvoiceTable(Table boqTable)
        {
            Name = boqTable.Name;
            Addition = boqTable.Premium;
            _sections = boqTable.Sections.Select(section => new InvoiceSection(section, boqTable.Count)).ToList();
        }
        public InvoiceTable(Table boqTable, InvoiceTable previousTable)
        {
            Name = boqTable.Name;
            Addition = boqTable.Premium;
            _sections = boqTable.Sections.Select(section => new InvoiceSection(section, previousTable.Sections.First(s => s.Id == section.Id), boqTable.Count)).ToList();
        }
        public void UpdateItem(long sectionId, long itemId, InvoiceItemUpdates updates)
        {
            InvoiceSection section = _sections.First(i => i.Id == sectionId);
            section.UpdateItem(itemId, updates);
        }

        /*public void UpdateCurrentQuantity(long sectionId, long itemId, double quantity, string userId)
        {
            InvoiceSection section = _sections.First(i => i.Id == sectionId);
            section.UpdateCurrentQuantity(itemId, quantity, userId);
        }
        public void UpdatePercentages(long sectionId, long itemId, List<InvoiceItemPercentage> percentages, string userId)
        {
            InvoiceSection section = _sections.First(i => i.Id == sectionId);
            section.UpdatePercentages(itemId, percentages, userId);
        }
        public void UpdateNotes(long sectionId, long itemId, string notes, string userId)
        {
            InvoiceSection section = _sections.First(i => i.Id == sectionId);
            section.UpdateNotes(itemId, notes, userId);
        }*/
    }
}
