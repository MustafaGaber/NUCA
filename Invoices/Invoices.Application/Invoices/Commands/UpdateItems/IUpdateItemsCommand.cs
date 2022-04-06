using NUCA.Invoices.Domain.Entities.Invoices;
using System.Collections.Generic;

namespace NUCA.Invoices.Application.Invoices.Commands.UpdateItems
{
    public interface IUpdateItemsCommand
    {
        Invoice Execute(long id, List<UpdateItemModel> updates, long userId);
    }
}
