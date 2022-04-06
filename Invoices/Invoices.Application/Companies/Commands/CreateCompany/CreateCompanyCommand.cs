using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Companies;

namespace NUCA.Invoices.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : ICreateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public Company Execute(CompanyModel model)
        {
            return _companyRepository.Add(new Company(model.Name));
        }

    }
}
