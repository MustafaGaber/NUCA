using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Domain.Entities.Invoices
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
