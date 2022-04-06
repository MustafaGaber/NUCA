using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateSection
{
    public interface ICreateSectionCommand
    {
        GetBoqModel Execute(long id, long tableId, CreateSectionModel section);
    }
}
