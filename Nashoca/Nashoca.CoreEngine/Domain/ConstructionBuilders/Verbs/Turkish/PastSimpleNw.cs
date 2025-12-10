using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class PastSimpleNw : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Rivayet Geçmiş Zaman";

        public PastSimpleNw(VerbInputObjTrEn input) : base(input) {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
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

        public override SuffixResult GetTense0Suffix(VerbPropsObj verbProps)
        {
            char? v = verbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

            return new SuffixResult()
            {
                Type = string.Format(VerbAnnotations.Tense0Suffix, "Not Witnessed Past Simple"),
                TypeSymbol = VerbAnnotations.Tense0Symbol,
                Value = $"m{v}ş",
                Description = string.Format(VerbAnnotations.Tense0InfoPastNw, v)
            };

            /*
            SuffixResult output = new()
            {
                Type = "Past Simple Tense Suffix",
                TypeSymbol = "tense0",
                Value = $"m{HarmonyInfo.BaseHarmony}ş",
                Description = $"m + {HarmonyInfo.BaseHarmony} + ş (according to the vowel harmony)."
            };

            if (verbProps.IsNegation)
            {
                output.Value = $"m{HarmonyInfo.IHarmony}ş";
                output.Description = $"m + {HarmonyInfo.IHarmony} + ş (according to the vowel harmony).";
            }
            else
            {
                output.Value = $"m{HarmonyInfo.BaseHarmony}ş";
                output.Description = $"m + {HarmonyInfo.BaseHarmony} + ş (according to the vowel harmony).";
            }

            return output;
            */
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
                if (verbProps.IsNegation || verbProps.Person == 8)
                {
                    output.Value = $"m{HarmonyInfo.IHarmony}";
                    output.Description = string.Format(VerbAnnotations.QuestionInfo, HarmonyInfo.IHarmony);
                }
                else
                {
                    output.Value = $"m{HarmonyInfo.BaseHarmony}";
                    output.Description = string.Format(VerbAnnotations.QuestionInfo, HarmonyInfo.BaseHarmony);
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

            if (verbProps.Person == 8)
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

            if (verbProps.Person == 8) return output;

            char? v = verbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

            //string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            output.Value = string.Format(VerbDataTr.cPersons[verbProps.Person - 1], v, HarmonyInfo.AEHarmony);
            output.Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType);

            return output;
        }
    }
}
