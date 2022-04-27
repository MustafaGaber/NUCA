using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand: IDeleteCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public DeleteCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void Execute(long id)
        {
            if (!_companyRepository.CompanyHasProjects(id))
            {
                _companyRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("Company has projects");
            }
        }
    }
}
