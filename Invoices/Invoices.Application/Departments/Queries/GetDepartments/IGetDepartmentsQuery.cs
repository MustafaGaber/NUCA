using System.Collections.Generic;

namespace NUCA.Invoices.Application.Departments.Queries.GetDepartments
{
    public interface IGetDepartmentsQuery
    {
        List<GetDepartmentModel> Execute();
    }
}
