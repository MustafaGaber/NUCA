using NUCA.Invoices.Application.Boqs.Models.GetBoq;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.CreateItem
{
    public interface ICreateItemCommand
    {
        GetBoqModel Execute(long projectId, long tableId, long sectionId, CreateItemModel item);
    }
}
