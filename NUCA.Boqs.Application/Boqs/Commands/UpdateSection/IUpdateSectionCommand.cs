using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.UpdateSection
{
    public interface IUpdateSectionCommand
    {
        void Execute(long projectId, long tableId, long sectionId, UpdateSectionModel section);
    }
}
