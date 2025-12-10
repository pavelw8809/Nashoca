using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class AbilityAorist : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Yeterlilik Kipi - Geniş Zaman";

        public AbilityAorist(VerbInputObjTrEn input) : base(input) {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
        }

        public override SuffixResult GetRootSuffix(VerbPropsObj verbProps)
        {   
            return new SuffixResult()
            {
                Type = VerbAnnotations.RootSuffix,
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMinF : $"{Input.TrPrefP} {Input.TrMinF}",
                Description = string.Format(VerbAnnotations.RootInfo, Input.TrName)
            };
        }

        public override SuffixResult GetNegationSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.RootSuffix,
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = null,
                Description = null
            };

            if (verbProps.IsNegation)
            {
                output.Value = $"m{HarmonyInfo.AEHarmony}";
                output.Description = string.Format(VerbAnnotations.NegationInfo, HarmonyInfo.AEHarmony);
            }

            return output;
        }

        public override SuffixResult GetTense0Suffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = string.Format(VerbAnnotations.Tense0Suffix, "Aorist"),
                TypeSymbol = VerbAnnotations.Tense0Symbol,
                Value = $"", //\u2205,
                Description = string.Format(VerbAnnotations.Tense0InfoEmpty, "Aorist", verbProps.PersonNumber, verbProps.PersonType)
            };

            if (verbProps.IsNegation)
            {
                if (verbProps.Person != 1 && verbProps.Person != 6 || verbProps.IsQuestion)
                {
                    output.Value = "z";
                    output.Description = string.Format(VerbAnnotations.Tense0InfoVal, "z", "Aorist", verbProps.PersonNumber, verbProps.PersonType);
                }
            }
            else
            {
                output.Value = "ir";
                output.Description = string.Format(VerbAnnotations.Tense0Info, "Aorist", "ir");
            }

            return output;
        }

        public override SuffixResult GetQuestionSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.QuestionSuffix,
                TypeSymbol = VerbAnnotations.QuestionSymbol,
                Value = null,
                Description = null
            };

            if (verbProps.IsQuestion)
            {
                if (verbProps.IsNegation)
                {
                    output.Value = $"m{HarmonyInfo.IHarmony}";
                    output.Description = string.Format(VerbAnnotations.QuestionInfo, HarmonyInfo.IHarmony);
                }
                else
                {
                    output.Value = "mi";
                    output.Description = string.Format(VerbAnnotations.QuestionInfo, "i");
                }
            }

            return output;
        }

        public override SuffixResult GetConsonantBuffer1(string formOutput, string personSuffix)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.ConsonantBufferSuffix,
                TypeSymbol = VerbAnnotations.ConsonantBufferSymbol,
                Value = null,
                Description = null
            };

            if (string.IsNullOrWhiteSpace(personSuffix)) return output;

            bool isPrevVowel = VowelHelper.IsLastCharVowel(formOutput);
            bool isPostVowel = VowelHelper.IsFirstCharVowel(personSuffix);

            if (isPrevVowel && isPostVowel)
            {
                output.Value = "y";
                output.Description = string.Format(VerbAnnotations.ConsBufInfo, StringHelper.GetLastLetter(formOutput), StringHelper.GetFirstLetter(personSuffix));
            }

            return output;
        }

        public override SuffixResult GetPluralSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.PluralSuffix,
                TypeSymbol = VerbAnnotations.PluralSymbol,
                Value = null,
                Description = null
            };

            if (verbProps.IsQuestion && verbProps.Person == 8)
            {
                string value = "ler";

                if (verbProps.IsNegation)
                {
                    value = $"l{HarmonyInfo.AEHarmony}r";
                }

                output.Value = value;
                output.Description = VerbAnnotations.PluralInfo;
            }

            return output;
        }

        public override SuffixResult GetPersonSuffix(VerbPropsObj verbProps)
        {
            char? v = verbProps.IsNegation ? HarmonyInfo.IHarmony : 'i';
            char? v2 = verbProps.IsNegation ? HarmonyInfo.AEHarmony : 'e';
            //string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{v2}r"];
            //string[] nPersons = ["m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{v2}r"];

            if (verbProps.IsQuestion && verbProps.Person == 8) return null;

            SuffixResult output = new()
            {
                Type = VerbAnnotations.PersonSuffix,
                TypeSymbol = VerbAnnotations.PersonSymbol,
                Value = string.Format(VerbDataTr.cPersons[verbProps.Person - 1], v, v2),
                Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType)
            };

            if (verbProps.IsNegation && !verbProps.IsQuestion)
            {
                output.Value = string.Format(VerbDataTr.cnPersons[verbProps.Person - 1], v, v2);
            }

            return output;
        }
    }
}
