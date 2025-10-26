using MediatR;
using Nashoca.Domain.Repositories;
using Nashoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Commands
{
    public class CreateVerbHandler : IRequestHandler<CreateVerbCommand, Unit>
    {
        private readonly IVerbRepository _repository;

        public CreateVerbHandler(IVerbRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateVerbCommand request, CancellationToken cancellation)
        {
            var dto = request.Verb;

            if (!Enum.TryParse<Case>(dto.VtrCase, ignoreCase: true, out var parsedCase)) {
                throw new ArgumentException($"Wrong VtrCase value: {dto.VtrCase}");
            }

            var verbTr = new VerbTr()
            {
                VtrSymbol = dto.VtrSymbol,
                VtrName = dto.VtrName,
                VtrPrefP = dto.VtrPrefP,
                VtrMainF = dto.VtrMainF,
                VtrMinF = dto.VtrMinF,
                VtrChgL = dto.VtrChgL,
                VtrAoristS = dto.VtrAoristS,
                VtrCase = parsedCase
            };

            var verbEn = new VerbEn()
            {
                VenSymbol = dto.VenSymbol,
                VenName = dto.VenName,
                VenPrefP = dto.VenPrefP,
                VenMainF = dto.VenMainF,
                VenMinF = dto.VenMinF,
                VenPastF = dto.VenPastF,
                VenPpastF = dto.VenPpastF,
                VenAdd = dto.VenAdd,
                VenExc = dto.VenExc
            };

            var verbTrans = new VerbTrans() {
                VtEn = dto.VtEn,
                VtGr = dto.VtGr,
                VtPl = dto.VtPl,
                VtRu = dto.VtRu,
                VtTr = dto.VtTr
            };

            Console.WriteLine($"VenSymbol: [{dto.VenSymbol}]");
            await _repository.AddVerbAsync(verbTr, verbEn, verbTrans);
            return Unit.Value;
        }
    }
}
