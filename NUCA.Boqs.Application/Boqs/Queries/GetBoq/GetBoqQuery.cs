using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Queries.GetBoq
{
    public class GetBoqQuery: IGetBoqQuery
    {
        private readonly IBoqRepository _repository;
        public GetBoqQuery(IBoqRepository repository)
        {
            _repository = repository;
        }
        public  GetBoqModel Execute(long id)
        {
            var boq = _repository.Get(id);
            return boq != null ? new GetBoqModel(boq) : null;
        }
    }
}
