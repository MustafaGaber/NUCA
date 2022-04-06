using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.UpdateItem
{
    public class UpdateItemCommand : IUpdateItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long projectId, long tableId, long sectionId, long itemId, UpdateItemModel item)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.UpdateItem(tableId, sectionId, itemId, item.Index, item.Content, item.Unit, item.Quantity, item.UnitPrice);
            _boqRepository.Update(boq);
        }
    }
}
