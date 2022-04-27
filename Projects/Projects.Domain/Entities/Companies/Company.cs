using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Entities.Companies
{
    public class Company : AggregateRoot
    {
        public string Name { get; private set; }
        protected Company() {}
        public Company(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
