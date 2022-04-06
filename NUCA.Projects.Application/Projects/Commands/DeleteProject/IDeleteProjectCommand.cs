using NUCA.Common.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Projects.Commands.DeleteProject
{
   public interface IDeleteProjectCommand
    {
        void Execute(long id);
    }
}
