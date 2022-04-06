using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Departments.Queries
{
   public class GetDepartmentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<long> GroupsIds { get; set; }
    }
}
