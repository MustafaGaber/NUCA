using NUCA.Invoices.Application.Departments;
using NUCA.Invoices.Domain.Entities.Companies;

namespace NUCA.Invoices.Application.Companies.Commands.UpdateCompany
{
    public interface IUpdateCompanyCommand
    {
        Company Execute(long id, CompanyModel model);
    }
}
