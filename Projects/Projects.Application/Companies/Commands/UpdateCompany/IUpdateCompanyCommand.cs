using NUCA.Projects.Application.Departments;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.UpdateCompany
{
    public interface IUpdateCompanyCommand
    {
        Company Execute(long id, CompanyModel model);
    }
}
