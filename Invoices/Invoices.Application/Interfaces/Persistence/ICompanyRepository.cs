using NUCA.Invoices.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Application.Interfaces.Persistence
{
    public interface  ICompanyRepository : IRepository<Company>
    {
        public bool CompanyHasProjects(long id);
    }
}
