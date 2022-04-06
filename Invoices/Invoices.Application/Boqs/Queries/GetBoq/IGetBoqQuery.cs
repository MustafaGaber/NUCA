using NUCA.Invoices.Application.Boqs.Models.GetBoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Queries.GetBoq
{
    public interface IGetBoqQuery
    {
        GetBoqModel Execute(long id);
    }
}
