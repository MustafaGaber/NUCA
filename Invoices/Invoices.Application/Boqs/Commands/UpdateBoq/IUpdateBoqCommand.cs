using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.UpdateBoq
{
    public interface IUpdateBoqCommand
    {
        void Execute(long id, UpdateBoqModel model);
    }
}
