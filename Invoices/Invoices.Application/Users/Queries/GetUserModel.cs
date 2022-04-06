using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Users.Queries
{
    public class GetUserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }

    public class DepartmentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
