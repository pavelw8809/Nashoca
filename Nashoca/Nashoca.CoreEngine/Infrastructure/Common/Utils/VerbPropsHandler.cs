using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Infrastructure.Common.Utils
{
    internal static class VerbPropsHandler
    {
        public static VerbPropsObj GetVerbProps(int formNo)
        {
            int constructCode = formNo / 100;
            int personNo = formNo % 10;
            int verbPropsCode = formNo / 10 % 10;

            int personNumber = personNo switch
            {
                1 => 1,
                2 => 2,
                3 or 4 or 5 => 3,
                6 => 1,
                7 => 2,
                8 => 3,
                _ => 0 // throw error
            };

            return new VerbPropsObj()
            {
                ConstructCode = constructCode,
                IsNegation = verbPropsCode == 1 || verbPropsCode == 3 || verbPropsCode == 5 || verbPropsCode == 7,
                IsQuestion = verbPropsCode == 2 || verbPropsCode == 3 || verbPropsCode == 6 || verbPropsCode == 7,
                Person = personNo,
                PersonNumber = personNumber,
                IsPlural = personNo >= 6,
                IsFormal = verbPropsCode > 3,
                PersonType = personNo >= 6 ? "plural" : "singular"
            };
        }
    }
}
