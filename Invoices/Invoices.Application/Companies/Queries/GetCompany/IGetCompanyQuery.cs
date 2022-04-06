
using NUCA.Invoices.Application.Departments;

namespace NUCA.Invoices.Application.Companies.Queries.GetCompany
{
    public interface IGetCompanyQuery
    {
        GetCompanyModel Execute(long id);
    }
}
