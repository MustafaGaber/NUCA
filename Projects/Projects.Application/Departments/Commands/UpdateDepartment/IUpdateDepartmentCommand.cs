using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Departments.Commands.UpdateDepartment
{
    public interface IUpdateDepartmentCommand
    {
        Department Execute(long id, DepartmentModel model);
    }
}
