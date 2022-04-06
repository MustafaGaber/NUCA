using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateItem
{
    public class CreateItemCommand : ICreateItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public GetBoqModel Execute(long projectId, long tableId, long sectionId, CreateItemModel item)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.AddItem(tableId, sectionId, item.Index, item.Content, item.Unit, item.Quantity, item.UnitPrice);
            _boqRepository.Update(boq);
            return new GetBoqModel(boq);
        }
    }
}
