using NUCA.Projects.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface  ICompanyRepository : IRepository<Company>
    {
        public bool CompanyHasProjects(long id);
    }
}
