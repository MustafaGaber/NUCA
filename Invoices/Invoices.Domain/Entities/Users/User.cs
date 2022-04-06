using Ardalis.GuardClauses;
using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Invoices.Domain.Entities.Users
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
