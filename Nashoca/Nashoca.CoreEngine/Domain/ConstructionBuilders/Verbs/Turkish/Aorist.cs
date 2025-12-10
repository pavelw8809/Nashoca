using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public class Aorist : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Geniş Zaman";

        public Aorist(VerbInputObjTrEn input) : base (input)
        {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
        }

        public override SuffixResult GetRootSuffix(VerbPropsObj verbProps)
        {
            string value = Input.TrMinF;
            string desc = string.Format(VerbAnnotations.RootInfo, Input.TrName);

            if (verbProps.IsNegation)
            {
                value = Input.TrMainF;
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
                output.Value = Input.TrAoS;
                output.Description = string.Format(VerbAnnotations.Tense0Info, "Aorist", Input.TrAoS);
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
                if (verbProps.IsNegation || verbProps.Person == 8)
                {
                    output.Value = $"m{HarmonyInfo.IHarmony}";
                    output.Description = $"Question Suffix: m + {HarmonyInfo.IHarmony}, according to the vowel harmony";
                } 
                else
                {
                    output.Value = $"m{HarmonyInfo.BaseHarmony}";
                    output.Description = $"Question Suffix: m + {HarmonyInfo.BaseHarmony}, according to the vowel harmony";

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
                output.Description = $"'y' consonant buffer between two vowels: {StringHelper.GetLastLetter(formOutput)} and {StringHelper.GetFirstLetter(personSuffix)}";
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
                output.Description = $"In 3rd. plural person, the plural suffix is added to the main verb word instead of the question suffix";
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

            char? v = verbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;
            //string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];
            //string[] nPersons = ["m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            if (verbProps.IsQuestion && verbProps.Person == 8) return output;

            if (verbProps.IsNegation && !verbProps.IsQuestion)
            {
                output.Value = string.Format(VerbDataTr.cnPersons[verbProps.Person - 1], v, HarmonyInfo.AEHarmony);
            }
            else
            {
                output.Value = string.Format(VerbDataTr.cPersons[verbProps.Person - 1], v, HarmonyInfo.AEHarmony);
            }

            output.Description = string.Format(VerbAnnotations.PersonInfo, verbProps.PersonNumber, verbProps.PersonType);

            return output;
        }
    }
}
