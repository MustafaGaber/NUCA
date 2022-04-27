using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Application.Companies.Commands.CreateCompany
{
   public  interface ICreateCompanyCommand
    {
        Company Execute(CompanyModel model);
    }
}
