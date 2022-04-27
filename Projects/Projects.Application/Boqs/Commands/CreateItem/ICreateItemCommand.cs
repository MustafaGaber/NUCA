using NUCA.Projects.Application.Boqs.Models.GetBoq;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public interface ICreateItemCommand
    {
        GetBoqModel Execute(long projectId, long tableId, long sectionId, CreateItemModel item);
    }
}
