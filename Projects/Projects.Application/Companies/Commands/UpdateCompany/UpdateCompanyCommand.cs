using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IUpdateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public Company Execute(long id, CompanyModel model)
        {
            var company = _companyRepository.Get(id);
            company.Update(model.Name);
            return _companyRepository.Update(company);
        }
    }
}
