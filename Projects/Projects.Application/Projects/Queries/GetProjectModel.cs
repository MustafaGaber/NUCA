using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Projects.Commands
{
    public class GetProjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DateTime> ModifiedEndDates { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Notes { get; set; }
        public double PrePaymentPercentage { get; set; }
    }
}
