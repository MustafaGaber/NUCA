using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.UpdateTable
{
    public class UpdateTableModel
    {
        public string TableName { get; set; }
        public int Count { get; set; }
        public double Addition { get; set; }
    }
}
