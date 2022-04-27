using NUCA.Projects.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
   public  interface IDepartmentRepository: IRepository<Department>
    {
        public Group GetGroup(long id);
        public bool DepartmentHasUsers(long id);
        public bool DepartmentHasProjects(long id);
    }
}
