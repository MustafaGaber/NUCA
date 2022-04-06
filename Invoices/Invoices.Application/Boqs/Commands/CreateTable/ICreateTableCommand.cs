using NUCA.Invoices.Application.Boqs.Models.GetBoq;
using NUCA.Invoices.Application.Boqs.Queries.GetBoq;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.CreateTable
{
    public interface ICreateTableCommand
    {
        GetBoqModel Execute(long boqId, CreateTableModel table);
    }
}
