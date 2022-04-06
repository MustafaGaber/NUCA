using Ardalis.GuardClauses;
using NUCA.Invoices.Domain.Entities.Departments;

namespace NUCA.Invoices.Domain.Entities.Users
{
    public class UserDepartment
    {
        public long DepartmentId { get; private set; }
        public long UserId { get; private set; }
        public User User { get; private set; }
        public Department Department { get; private set; }
        protected UserDepartment() { }
        public UserDepartment(User user, Department department)
        {
            User = Guard.Against.Null(user, nameof(user));
            UserId = user.Id;
            Department = Guard.Against.Null(department, nameof(department));
            DepartmentId = department.Id;
        }

    }
}
