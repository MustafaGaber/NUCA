
using System.Collections.Generic;

namespace NUCA.Invoices.Application.Departments
{
    public class DepartmentModel
    {
        public string Name { get; set; }
        public List<long> GroupsIds { get; set; }
    }
}
