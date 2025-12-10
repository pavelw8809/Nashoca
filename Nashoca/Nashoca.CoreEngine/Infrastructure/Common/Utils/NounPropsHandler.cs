using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Common.Utils
{
    public static class NounPropsHandler
    {
        public record Person(bool IsPlural, int PersonNo);

        public static NounPropsObj GetNounProps(int formNo)
        {
            // 0 0 0  1  0
            // T C PN PS PR

            int personNo = formNo % 10;
            int possesiveNo = formNo / 10 % 10;
            int nounPropsCode = formNo / 100 % 10;
            int caseCode = formNo / 1000 % 10;
            int constructCode = formNo / 10000;

            bool isNegation = nounPropsCode == 2 || nounPropsCode == 4;
            bool isPlural = nounPropsCode == 1;

            if (caseCode == 8)
            {
                isNegation = nounPropsCode > 3;
                isPlural = nounPropsCode % 2 != 0;
            }

            /*
            if (caseCode == 9)
            {
                isNegation = false;
                isPlural = nounPropsCode % 2 != 0;
            }
            */

            Person personObj = GetPerson(personNo);
            Person possesiveObj = GetPerson(possesiveNo);

            return new NounPropsObj()
            {
                IsPlural = isPlural,
                Case = caseCode,
                PossesivePersonNumber = possesiveObj.PersonNo,
                IsPossesivePersonPlural = possesiveObj.IsPlural,
                Person = personNo,
                PersonNumber = personObj.PersonNo,
                PersonType = personObj.IsPlural ? "plural" : "singilar",
                IsPersonPlural = personObj.IsPlural,
                IsNegation = isNegation,
                IsQuestion = nounPropsCode == 3 || nounPropsCode == 4,
                ConstructCode = constructCode
            };
        }

        private static dynamic GetPerson(int number)
        {
            bool isPlural = number > 5;
            int personNo = number switch
            {
                1 => 1,
                2 => 2,
                3 or 4 or 5 => 3,
                6 => 1,
                7 => 2,
                8 => 3,
                _ => 0
            };

            return new Person(isPlural, personNo);
        }
    }
}
