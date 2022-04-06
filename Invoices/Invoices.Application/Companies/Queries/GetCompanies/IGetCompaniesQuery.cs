using NUCA.Invoices.Application.Departments;
using System.Collections.Generic;

namespace NUCA.Invoices.Application.Companies.Queries.GetCompanies
{
    public interface IGetCompaniesQuery
    {
        List<GetCompanyModel> Execute();
    }
}
