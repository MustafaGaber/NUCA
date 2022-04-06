using NUCA.Invoices.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Application.Interfaces.Persistence
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
    }
}
