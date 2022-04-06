using NUCA.Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class ModifiedEndDate : Entity
    {
        public virtual DateTime Date { get; }
        protected ModifiedEndDate() { }
        public ModifiedEndDate(DateTime date)
        {
            Date = date;
        }

    }
}
