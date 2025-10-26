using MediatR;
using Microsoft.EntityFrameworkCore;
using Nashoca.Application.DTOs;
using Nashoca.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Queries
{
    public class GetAllVerbsHandler : IRequestHandler<GetAllVerbsQuery, List<VerbDto>>
    {
        private readonly MainDbContext _context;

        public GetAllVerbsHandler(MainDbContext context)
        {
            _context = context;
        }

        public async Task<List<VerbDto>> Handle(GetAllVerbsQuery request, CancellationToken cancellationToken)
        {
            var verbs = await _context.VerbsTrans
                .Include(v => v.VerbTr)
                .Include(v => v.VerbEn)
                .ToListAsync();

            return verbs.Select(v => new VerbDto
            {
                VtrSymbol = v.VerbTr?.VtrSymbol,
                VtrName = v.VerbTr?.VtrName,
                VtrPrefP = v.VerbTr?.VtrPrefP,
                VtrMainF = v.VerbTr?.VtrMainF,
                VtrChgL = v.VerbTr?.VtrChgL,
                VtrAoristS = v.VerbTr?.VtrAoristS,
                VtrCase = v.VerbTr?.VtrCase.ToString(),
                VenSymbol = v.VerbEn?.VenSymbol,
                VenName = v.VerbEn?.VenName,
                VenMainF = v.VerbEn?.VenMainF,
                VenMinF = v.VerbEn?.VenMinF,
                VenPastF = v.VerbEn?.VenPastF,
                VenPpastF = v.VerbEn?.VenPpastF,
                VenAdd = v.VerbEn?.VenAdd,
                VenExc = v.VerbEn?.VenExc,
                VtEn = v.VtEn,
                VtGr = v.VtGr,
                VtPl = v.VtPl,
                VtRu = v.VtRu,
                VtTr = v.VtTr
            }).ToList();
        }
    }
}
