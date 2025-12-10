using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class PresentContinuous : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Şimdiki Zaman";
        public PresentContinuous(VerbInputObjTrEn input) : base (input)
        {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
        }

        public override SuffixResult GetRootSuffix(VerbPropsObj verbProps)
        {
            string value = Input.TrMinF;
            string desc = $"Basic verb form from: {Input.TrName}";

            if (verbProps.IsNegation)
            {
                value = Input.TrMainF;
            }
            else
            {
                if (HarmonyInfo.IsLastCharVowel)
                {
                    value = value[..^1] + HarmonyInfo.BaseHarmony;
                    desc = $"Changing the last letter from: {Input.TrMinF.Last()} to: {HarmonyInfo.BaseHarmony} according to the vowel harmony";
                }
            }

            return new SuffixResult()
            {
                Type = VerbAnnotations.RootSuffix,
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? value : $"{Input.TrPrefP} {value}",
                Description = desc
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
                output.Value = "m";
                output.Description = VerbAnnotations.NegationPcInfo;
            }

            return output;
        }

        public override SuffixResult GetTense0Suffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new SuffixResult()
            {
                Type = string.Format(VerbAnnotations.Tense0Suffix, "Present Continuous"),
                TypeSymbol = VerbAnnotations.Tense0Symbol,
                Value = "yor",
                Description = string.Format(VerbAnnotations.Tense0Info, "Present Continuous", "yor")
            };

            if (verbProps.IsNegation)
            {
                output.Value = $"{HarmonyInfo.BaseHarmony}yor";
                output.Description = $"Harmony vowel: {HarmonyInfo.BaseHarmony} + yor";
            }
            else
            {
                if (!HarmonyInfo.IsLastCharVowel)
                {
                    output.Value = $"{HarmonyInfo.BaseHarmony}yor";
                    output.Description = string.Format(VerbAnnotations.Tense0InfoPc, HarmonyInfo.BaseHarmony);
                }
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
                if (verbProps.Person == 8)
                {
                    output.Value = "mı";
                    output.Description = string.Format(VerbAnnotations.NegationInfo, "ı");
                } 
                else
                {
                    output.Value = "mu";
                    output.Description = string.Format(VerbAnnotations.NegationInfo, "u");
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
                output.Value = "lar";
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

            //string[] persons = ["um", "sun", "", "", "", "uz", "sunuz", "lar"];

            output.Value = string.Format(VerbDataTr.cPersons[verbProps.Person - 1], "u", "a");
            output.Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType);

            return output;
        }
    }
}
