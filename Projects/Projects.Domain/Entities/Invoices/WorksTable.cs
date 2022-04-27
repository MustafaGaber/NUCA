using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Domain.Entities.Invoices
{
    public class WorksTable: InvoiceTable
    {
        protected WorksTable() { }
        public WorksTable(Table boqTable): base(boqTable)
        {
          
        }
        public WorksTable(Table boqTable, WorksTable previousTable) : base(boqTable, previousTable)
        {

        }
    }
}
