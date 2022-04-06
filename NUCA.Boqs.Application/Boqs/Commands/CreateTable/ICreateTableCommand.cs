using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Application.Boqs.Queries.GetBoq;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateTable
{
    public interface ICreateTableCommand
    {
        GetBoqModel Execute(long boqId, CreateTableModel table);
    }
}
