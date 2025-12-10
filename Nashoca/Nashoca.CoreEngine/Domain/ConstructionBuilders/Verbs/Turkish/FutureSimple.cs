using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class FutureSimple : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Gelecek Zaman";

        public FutureSimple(VerbInputObjTrEn input) : base(input) {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
        }

        public override SuffixResult GetRootSuffix(VerbPropsObj verbProps)
        {
            string value = Input.TrMinF;

            if (verbProps.IsNegation)
            {
                value = Input.TrMainF;
            }

            return new SuffixResult()
            {
                Type = VerbAnnotations.RootSuffix,
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? value : $"{Input.TrPrefP} {value}",
                Description = string.Format(VerbAnnotations.RootInfo, Input.TrName)
            };
        }

        public override SuffixResult GetNegationSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.NegationSuffix,
                TypeSymbol = VerbAnnotations.NegationSymbol,
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

        public override SuffixResult GetTense0PreSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.Tense0PreSuffix,
                TypeSymbol = VerbAnnotations.Tense0PreSymbol,
                Value = null,
                Description = null
            };

            if (verbProps.IsNegation || HarmonyInfo.IsLastCharVowel)
            {
                output.Value = "y";
                output.Description = VerbAnnotations.Tense0PreInfo;
            }

            return output;
        }

        public override SuffixResult GetTense0Suffix(VerbPropsObj verbProps)
        {
            string v = $"{HarmonyInfo.AEHarmony}";
            string value = !verbProps.IsQuestion && (verbProps.Person == 1 || verbProps.Person == 6) ? $"{v}c{v}ğ" : $"{v}c{v}k";
            string desc = !verbProps.IsQuestion && (verbProps.Person == 1 || verbProps.Person == 6) ? string.Format(VerbAnnotations.Tense0InfoFuture, "k", "ğ") : string.Format(VerbAnnotations.Tense0Info, "Future Simple", value);
            //string desc = !verbProps.IsQuestion && (verbProps.Person == 1 || verbProps.Person == 6) ? $"'k' changes to 'ğ' because the next suffix person starts from a vowel" : $"Basic Future Simple tense suffix";

            return new SuffixResult()
            {
                Type = string.Format(VerbAnnotations.RootSuffix, "Future Simple"),
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = value,
                Description = desc
            };
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
                //if (VerbProps.Person == 8) return null;
                output.Value = $"m{HarmonyInfo.IHarmony}";
                output.Description = string.Format(VerbAnnotations.QuestionInfo, HarmonyInfo.IHarmony);
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
                output.Value = $"l{HarmonyInfo.AEHarmony}r";
                output.Description = VerbAnnotations.PluralInfo;
            }

            return output;
        }

        public override SuffixResult GetPersonSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.PersonSuffix,
                TypeSymbol = VerbAnnotations.PersonSymbol,
                Value = null,
                Description = null
            };

            char? v = HarmonyInfo.IHarmony;
            //string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            if (verbProps.IsQuestion && verbProps.Person == 8) return output;

            output.Value = string.Format(VerbDataTr.cPersons[verbProps.Person - 1], v, HarmonyInfo.AEHarmony);
            output.Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType);

            return output;
        }
    }
}
