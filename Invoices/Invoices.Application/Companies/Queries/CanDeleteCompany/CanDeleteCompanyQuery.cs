using NUCA.Invoices.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Companies.Queries.CanDeleteCompany
{
    class CanDeleteCompanyQuery : ICanDeleteCompanyQuery
    {
        private readonly ICompanyRepository _repository;
        public CanDeleteCompanyQuery(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public bool Execute(long id)
        {
            return !_repository.CompanyHasProjects(id);
        }
    }
}
