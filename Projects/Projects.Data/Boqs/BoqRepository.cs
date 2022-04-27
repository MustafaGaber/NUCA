using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Data.Boqs
{
    public class BoqRepository : Repository<Boq>, IBoqRepository
    {
        public BoqRepository(DatabaseContext database)
           : base(database) { }

        public override IEnumerable<Boq> All()
        {
            return database.Boqs
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ToList();
        }
        public override Boq Get(long id)
        {
            return database.Boqs
                .Include(b => b.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
