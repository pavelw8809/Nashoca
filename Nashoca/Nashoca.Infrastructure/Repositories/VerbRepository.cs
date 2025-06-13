using Nashoca.Domain.Repositories;
using Nashoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nashoca.Intrastructure;

namespace Nashoca.Infrastructure.Repositories
{
    public class VerbRepository : IVerbRepository
    {
        private readonly MainDbContext _context;

        public VerbRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task AddVerbAsync(VerbTr verbTr, VerbEn verbEn, VerbTrans verbTrans)
        {
            _context.VerbsTr.Add(verbTr);
            _context.VerbsEn.Add(verbEn);
            _context.VerbsTrans.Add(verbTrans);
            await _context.SaveChangesAsync();
        }
    }
}
