using Ardalis.GuardClauses;
using NUCA.Common.DDD;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Project : AggregateRoot
    {
        private readonly List<ModifiedEndDate> _modifiedEndDates = new List<ModifiedEndDate>();
        public string Name { get; private set; }
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public int? OrderNumber { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public virtual IReadOnlyList<ModifiedEndDate> ModifiedEndDates => _modifiedEndDates.ToList(); 
        public long? CompanyId { get; private set; }
        public string? CompanyName { get; private set; }
        public string Notes { get; private set; }
        public double PrePaymentPercentage { get; private set; }
        protected Project() { }
        public Project(string name, int departmentId, string departmentName, int? orderNumber, DateTime orderDate, DateTime endDate,
            List<ModifiedEndDate> modifiedEndDates, long? companyId, string? companyName, string notes, double prePaymentPercentage)
        {
            Update(name, departmentId, departmentName, orderNumber, orderDate, endDate, modifiedEndDates, companyId, companyName, notes, prePaymentPercentage);
        }

        public void Update(string name, int departmentId, string departmentName, int? orderNumber, DateTime orderDate, DateTime endDate,
    List<ModifiedEndDate> modifiedEndDates, long? companyId, string? companyName, string notes, double prePaymentPercentage)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            DepartmentId = Guard.Against.NegativeOrZero(departmentId, nameof(departmentId));
            DepartmentName = Guard.Against.Null(departmentName, nameof(departmentName));
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            EndDate = endDate;
            _modifiedEndDates.Clear();
            _modifiedEndDates.AddRange(modifiedEndDates);
            CompanyId = companyId;
            CompanyName = companyName;
            Notes = notes;
            PrePaymentPercentage = Guard.Against.Negative(prePaymentPercentage, nameof(prePaymentPercentage));
        }

    }
}
