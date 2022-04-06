using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Companies;

namespace NUCA.Invoices.Application.Companies.Commands.UpdateCompany
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
