using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Projects
{
   public class ProjectModel
    {
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> ModifiedEndDates { get; set; }
        public long CompanyId { get; set; }
        public string Notes { get; set; }
        public double PrePaymentPercentage { get; set; }
    }
}
