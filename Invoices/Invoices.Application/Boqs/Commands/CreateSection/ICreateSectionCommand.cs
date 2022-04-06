using NUCA.Invoices.Application.Boqs.Models.GetBoq;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.CreateSection
{
    public interface ICreateSectionCommand
    {
        GetBoqModel Execute(long id, long tableId, CreateSectionModel section);
    }
}
