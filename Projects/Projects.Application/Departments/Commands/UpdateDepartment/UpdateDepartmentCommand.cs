using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IUpdateDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentCommand(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Department Execute(long id, DepartmentModel model)
        {
            List<Group> groups = model.GroupsIds.Select(id => _departmentRepository.GetGroup(id)).Where(g => g != null).ToList();
            var department = _departmentRepository.Get(id);
            department.Update(model.Name, groups);
            return _departmentRepository.Update(department);
        }
    }
}
