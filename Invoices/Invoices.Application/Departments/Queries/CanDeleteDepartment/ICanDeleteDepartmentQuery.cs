using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Departments.Queries.CanDeleteDepartment
{
    public interface ICanDeleteDepartmentQuery
    {
        public bool Execute(long id);
    }
}
