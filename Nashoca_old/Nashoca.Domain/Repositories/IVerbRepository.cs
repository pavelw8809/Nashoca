using Nashoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Domain.Repositories
{
    public interface IVerbRepository
    {
        Task AddVerbAsync(VerbTr verbTr, VerbEn vernEn, VerbTrans verbTrans);
    }
}
