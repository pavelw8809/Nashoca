using Microsoft.EntityFrameworkCore;
using Nashoca.Domain.Entities;
using Nashoca.Domain.Repositories;
using Nashoca.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Console.WriteLine(verbEn.VenSymbol);
            //Console.WriteLine($"Stan encji VerbTr przed zapisem: {_context.Entry(verbTr).State}");
            //Console.WriteLine($"Stan encji VerbEn przed zapisem: {_context.Entry(verbEn).State}");
            _context.VerbsEn.Add(verbEn);
            await _context.SaveChangesAsync();
            //_context.Entry(verbEn).State = EntityState.Added;
            //await _context.SaveChangesAsync();

            _context.VerbsTr.Add(verbTr);
            await _context.SaveChangesAsync();
            Console.WriteLine($"VenSymbol po dodaniu do kontekstu: [{verbEn.VenSymbol}]");
            Console.WriteLine($"Stan encji przed zapisem: {_context.Entry(verbEn).State}");
            _context.VerbsTrans.Add(verbTrans);
            await _context.SaveChangesAsync();
        }
    }
}
