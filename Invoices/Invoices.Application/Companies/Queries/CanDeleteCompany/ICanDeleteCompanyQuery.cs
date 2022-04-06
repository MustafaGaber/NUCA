using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Companies.Queries.CanDeleteCompany
{
    public interface ICanDeleteCompanyQuery
    {
         bool Execute(long id);
    }
}
