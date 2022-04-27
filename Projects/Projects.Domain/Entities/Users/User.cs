using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Users
{
    public class User: AggregateRoot
    {
        private readonly List<UserDepartment> _departments = new List<UserDepartment>();
        public virtual IReadOnlyList<UserDepartment> Departments => _departments.ToList();
        public string Name { get; private set; }
        protected User() { }
        public User(string name, List<Department> departments)
        {
            Update(name, departments);
        }

        public void Update(string name, List<Department> departments)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            _departments.Clear();
            _departments.AddRange(departments.Select(d => new UserDepartment(this, d)).ToList());
        }

    }
}
