using NUCA.Invoices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Application.Projects.Commands.DeleteProject
{
   public interface IDeleteProjectCommand
    {
        void Execute(long id);
    }
}
