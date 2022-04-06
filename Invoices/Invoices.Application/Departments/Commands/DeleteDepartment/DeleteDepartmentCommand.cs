using NUCA.Invoices.Application.Interfaces.Persistence;
using System.Linq;
using System;
namespace NUCA.Invoices.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand: IDeleteDepartmentCommand
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProjectRepository _projectRepository;
        public DeleteDepartmentCommand(IDepartmentRepository departmentRepository, IProjectRepository projectRepository)
        {
            _departmentRepository = departmentRepository;
            _projectRepository = projectRepository;
        }
        public void Execute(long id)
        {
           if(!_departmentRepository.DepartmentHasProjects(id) && !_departmentRepository.DepartmentHasUsers(id)) {
                _departmentRepository.Delete(id);
            } else {
                throw new InvalidOperationException("Department has projects or users");
            }
        }
    }
}
