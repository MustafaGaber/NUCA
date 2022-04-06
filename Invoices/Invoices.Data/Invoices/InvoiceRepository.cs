using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Invoices;
using NUCA.Invoices.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Data.Invoices
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DatabaseContext database)
         : base(database) { }

        public override IEnumerable<Invoice> All()
        {
            return database.Invoices
                .Include(i => i.SuppliesTables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ThenInclude(i => i.Percentages)
                .Include(i => i.WorksTables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ThenInclude(i => i.Percentages)
                .ToList();
        }
        public override Invoice Get(long id)
        {
            return database.Invoices
                .Include(i => i.SuppliesTables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ThenInclude(i => i.Percentages)
                .Include(i => i.WorksTables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ThenInclude(i => i.Percentages)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
