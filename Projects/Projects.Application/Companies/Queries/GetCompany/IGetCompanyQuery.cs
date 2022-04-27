
using NUCA.Projects.Application.Departments;

namespace NUCA.Projects.Application.Companies.Queries.GetCompany
{
    public interface IGetCompanyQuery
    {
        GetCompanyModel Execute(long id);
    }
}
