using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Application.Companies.Queries.GetCompanies
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
