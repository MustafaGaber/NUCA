using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.CreateCompany
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
