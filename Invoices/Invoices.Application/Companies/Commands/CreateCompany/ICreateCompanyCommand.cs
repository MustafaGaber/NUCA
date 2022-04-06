using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Companies;

namespace NUCA.Invoices.Application.Companies.Commands.CreateCompany
{
   public  interface ICreateCompanyCommand
    {
        Company Execute(CompanyModel model);
    }
}
