using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Invoices.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : IGetCompaniesQuery
    {

        private readonly ICompanyRepository _repository;

        public GetCompaniesQuery(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public List<GetCompanyModel> Execute()
        {
            return _repository.All().Select(company => new GetCompanyModel
            {
                   Id = company.Id,
                   Name = company.Name,
               }).ToList();
        }
    }
}
