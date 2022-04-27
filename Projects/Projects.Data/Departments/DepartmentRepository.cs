using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Departments
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DatabaseContext database)
         : base(database) { }

        public override IEnumerable<Department> All()
        {
            return database.Departments.Include(d => d.Groups).ToList();
        }
        public override IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            return database.Departments
                .Include(u => u.Groups).ThenInclude(d => d.Department)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }
        public override Department Get(long id)
        {
            return database.Departments.Include(d => d.Groups).FirstOrDefault(d => d.Id == id);
        }

        public Group GetGroup(long id)
        {
            return database.Set<Group>().Find(id);
        }

        public bool DepartmentHasUsers(long id)
        {
            return database.Users.Include(u => u.Departments).Where(u => u.Departments.Select(d => d.DepartmentId).Contains(id)).Count() > 0;
        }

        public bool DepartmentHasProjects(long id)
        {
            return database.Projects.Include(p => p.Department).Where(p => p.Department.Id == id).Count() > 0;
        }
    }
}
