
namespace NUCA.Invoices.Application.Departments.Queries.GetDepartment
{
    public interface IGetDepartmentQuery
    {
        GetDepartmentModel Execute(long id);
    }
}
