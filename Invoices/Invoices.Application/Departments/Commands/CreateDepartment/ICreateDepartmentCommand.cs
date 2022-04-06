using NUCA.Invoices.Domain.Entities.Departments;

namespace NUCA.Invoices.Application.Departments.Commands.CreateDepartment
{
    public interface ICreateDepartmentCommand
    {
        Department Execute(DepartmentModel model);
    }
}
