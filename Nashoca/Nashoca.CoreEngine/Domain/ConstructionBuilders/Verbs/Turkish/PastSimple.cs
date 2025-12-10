using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class PastSimple : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Belirli Geçmiş Zaman";

        public PastSimple(VerbInputObjTrEn input) : base(input) { 
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
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
                Type = string.Format(VerbAnnotations.Tense0Suffix, "Past Simple"),
                TypeSymbol = VerbAnnotations.Tense0Symbol,
                Value = $"d{HarmonyInfo.BaseHarmony}",
                Description = string.Format(VerbAnnotations.Tense0InfoPastD, "Past Simple", HarmonyInfo.BaseHarmony)
            };

            if (verbProps.IsNegation)
            {
                output.Value = $"d{HarmonyInfo.IHarmony}";
                output.Description = string.Format(VerbAnnotations.Tense0InfoPastD, "Past Simple", HarmonyInfo.IHarmony);
            }
            else
            {
                if (HarmonyInfo.IsLastCharVoiceless)
                {
                    output.Value = $"t{HarmonyInfo.BaseHarmony}";
                    output.Description = string.Format(VerbAnnotations.Tense0InfoPastT, "Past Simple", HarmonyInfo.BaseHarmony);
                }
                else
                {
                    output.Value = $"d{HarmonyInfo.BaseHarmony}";
                    output.Description = string.Format(VerbAnnotations.Tense0InfoPastD, "Past Simple", HarmonyInfo.BaseHarmony);
                }
            }

            return output;
        }

        public override SuffixResult GetPersonSuffix(VerbPropsObj verbProps)
        {
            char? v = verbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

            //string[] persons = ["m", "n", "", "", "", "k", $"n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            return new SuffixResult()
            {
                Type = VerbAnnotations.PersonSuffix,
                TypeSymbol = VerbAnnotations.PersonSymbol,
                Value = string.Format(VerbDataTr.pPersons[verbProps.Person - 1], v, HarmonyInfo.AEHarmony),
                Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType)
            };
        }

        public override SuffixResult GetQuestionPostSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.QuestionPostSuffix,
                TypeSymbol = VerbAnnotations.QuestionPostSymbol,
                Value = null,
                Description = null
            };

            if (verbProps.IsQuestion)
            {
                char? v = verbProps.IsNegation || verbProps.Person == 8 ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

                output.Value = $"m{v}";
                output.Description = string.Format(VerbAnnotations.QuestionPostInfo, v);
            }

            return output;
        }
    }
}
