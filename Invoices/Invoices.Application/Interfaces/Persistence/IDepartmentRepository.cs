using NUCA.Invoices.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Application.Interfaces.Persistence
{
   public  interface IDepartmentRepository: IRepository<Department>
    {
        public Group GetGroup(long id);
        public bool DepartmentHasUsers(long id);
        public bool DepartmentHasProjects(long id);
    }
}
