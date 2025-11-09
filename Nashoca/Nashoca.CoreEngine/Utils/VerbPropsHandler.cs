using Nashoca.CoreEngine.Models.Verbs;

namespace Nashoca.CoreEngine.Utils
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

            bool isPlural = personNo >= 6;
            string personType = isPlural ? "plural" : "singular";

            return new VerbPropsObj()
            {
                ConstructCode = constructCode,
                IsNegation = verbPropsCode == 1 || verbPropsCode == 3,
                IsQuestion = verbPropsCode == 2 || verbPropsCode == 3,
                Person = personNo,
                PersonNumber = personNumber,
                IsPlural = isPlural,
                PersonType = personType
            };
        }
    }
}
