using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Project : AggregateRoot
    {
        private readonly List<ModifiedEndDate> _modifiedEndDates = new List<ModifiedEndDate>();
        public string Name { get; private set; }
        public Department Department { get; private set; }
        public int? OrderNumber { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public virtual IReadOnlyList<ModifiedEndDate> ModifiedEndDates => _modifiedEndDates.ToList(); 
        public Company Company { get; private set; }
        public string Notes { get; private set; }
        public double PrePaymentPercentage { get; private set; }
        protected Project() { }
        public Project(string name, Department department, int? orderNumber, DateTime orderDate, DateTime endDate,
            List<ModifiedEndDate> modifiedEndDates, Company company, string notes, double prePaymentPercentage)
        {
            Update(name, department, orderNumber, orderDate, endDate, modifiedEndDates, company, notes, prePaymentPercentage);
        }

        public void Update(string name, Department department, int? orderNumber, DateTime orderDate, DateTime endDate,
    List<ModifiedEndDate> modifiedEndDates, Company company, string notes, double prePaymentPercentage)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Department = Guard.Against.Null(department, nameof(department));
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            EndDate = endDate;
            _modifiedEndDates.Clear();
            _modifiedEndDates.AddRange(modifiedEndDates);
            Company = company;
            Notes = notes;
            PrePaymentPercentage = Guard.Against.Negative(prePaymentPercentage, nameof(prePaymentPercentage));
        }

    }
}
