using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Domain.Entities.Invoices
{
    public class SuppliesTable : InvoiceTable
    {
        protected SuppliesTable() { }
        public SuppliesTable(Table boqTable) : base(boqTable)
        {

        }
        public SuppliesTable(Table boqTable, SuppliesTable previousTable) : base(boqTable, previousTable)
        {

        }
    }
}
