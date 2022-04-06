using NUCA.Invoices.Domain.Entities.Departments;

namespace NUCA.Invoices.Application.Departments.Commands.UpdateDepartment
{
    public interface IUpdateDepartmentCommand
    {
        Department Execute(long id, DepartmentModel model);
    }
}
