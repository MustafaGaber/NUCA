using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.UpdateItem
{
    public interface IUpdateItemCommand
    {
        void Execute(long projectId, long tableId, long sectionId, long itemId, UpdateItemModel item);
    }
}
