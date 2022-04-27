using NUCA.Projects.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Departments.Queries.CanDeleteDepartment
{
    public class CanDeleteDepartmentQuery : ICanDeleteDepartmentQuery
    {
        private readonly IDepartmentRepository _repository;
        public CanDeleteDepartmentQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public bool Execute(long id)
        {
            return !_repository.DepartmentHasProjects(id) && !_repository.DepartmentHasUsers(id);
        }
    }
}
