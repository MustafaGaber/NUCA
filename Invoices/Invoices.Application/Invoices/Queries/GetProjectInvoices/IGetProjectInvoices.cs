using NUCA.Invoices.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Invoices.Queries.GetProjectInvoices
{
    public interface IGetProjectInvoices
    {
        List<Invoice> Execute(long projectId);
    }
}
