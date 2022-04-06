﻿using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Users;
using NUCA.Invoices.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NUCA.Invoices.Data.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext database)
         : base(database) { }

        public override IEnumerable<User> All()
        {
            return database.Users.Include(u => u.Departments).ThenInclude(d=> d.Department).ToList();
        }

        public override IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return database.Users
                .Include(u => u.Departments).ThenInclude(d => d.Department)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }
        public override User Get(long id)
        {
            return database.Users.Include(u => u.Departments).ThenInclude(d => d.Department).FirstOrDefault(u => u.Id == id);
        }
    }
}
