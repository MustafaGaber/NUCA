using NUCA.Projects.Application.Boqs.Models.GetBoq;
using NUCA.Projects.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Queries.GetBoq
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
