using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Projects;
using NUCA.Invoices.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Invoices.Domain.Entities.Departments
{
    public class Department: AggregateRoot
    {
        private readonly List<DepartmentGroup> _groups = new List<DepartmentGroup>();
        public string Name { get; private set; }
        public virtual IReadOnlyList<DepartmentGroup> Groups => _groups.ToList();
        protected Department() { }
        public Department(string name)
        {
            Name = name;
        }
        public Department(string name, List<Group> groups)
        {
            Name = name;
            _groups = groups.Select(g => new DepartmentGroup(this, g)).ToList();
        }

        public void AddToGroup(Group group)
        {
            _groups.Add(new DepartmentGroup(this, group));
        }

        public void Update(string name, List<Group> groups)
        {
            Name = name;
            _groups.Clear();
            _groups.AddRange(groups.Select(g => new DepartmentGroup(this, g)));
        }

        public void RemoveFromGroup(DepartmentGroup group)
        {
            DepartmentGroup item = _groups.Find(s => s.Group.Id == group.Group.Id);
            if (item != null)
            {
                _groups.Remove(item);
            }
        }
    }
}
