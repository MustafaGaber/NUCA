using System.Collections.Generic;

namespace NUCA.Projects.Application.Departments.Queries.GetDepartments
{
    public interface IGetDepartmentsQuery
    {
        List<GetDepartmentModel> Execute();
    }
}
