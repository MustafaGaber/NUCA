using NUCA.Projects.Domain.Entities.Invoices;
using System.Collections.Generic;

namespace NUCA.Projects.Application.Invoices.Commands.UpdateItems
{
    public interface IUpdateItemsCommand
    {
        Invoice Execute(long id, List<UpdateItemModel> updates, long userId);
    }
}
