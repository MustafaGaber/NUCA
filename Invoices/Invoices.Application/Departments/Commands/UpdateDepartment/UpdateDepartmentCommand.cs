using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Departments;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Departments.Commands.UpdateDepartment
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
