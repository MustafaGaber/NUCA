using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.CreateBoq
{
    public interface ICreateBoqCommand
    {
        Boq Execute(long id, CreateBoqModel model);
    }
}
