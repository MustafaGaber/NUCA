using System.Collections.Generic;

namespace NUCA.Projects.Application.Users
{
    public class UserModel
    {
        public string Name { get; set; }
        public List<long> DepartmentsIds { get; set; }
    }
}
