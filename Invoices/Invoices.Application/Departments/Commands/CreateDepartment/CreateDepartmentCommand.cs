using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Departments;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : ICreateDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentCommand(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Department Execute(DepartmentModel model)
        {
            List<Group> groups = model.GroupsIds.Select(id => _departmentRepository.GetGroup(id)).Where(g => g != null).ToList();
            return _departmentRepository.Add(new Department(model.Name, groups));
        }
    }
}
