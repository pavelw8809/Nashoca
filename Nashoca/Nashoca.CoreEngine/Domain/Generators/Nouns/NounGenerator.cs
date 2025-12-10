using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.Generators.Nouns
{
    public class NounGenerator : IFormGenerator<NounInputObjTrEn, NounOutputObjTrEn>
    {
        public ICollection<NounOutputObjTrEn> GenerateMany(NounInputObjTrEn inputObj, List<int>formList)
        {
            return null;
        }

        public NounOutputObjTrEn GenerateOne(NounInputObjTrEn inputObj, int formNo)
        {
            return null;
        }
    }
}