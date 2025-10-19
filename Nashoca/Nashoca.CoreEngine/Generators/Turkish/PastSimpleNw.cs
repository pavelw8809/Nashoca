using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public class PastSimpleNw : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Rivayet Geçmiş Zaman";

        public PastSimpleNw(InputObjTrEn input) : base(input) {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
        }

        public override SuffixResult GetRootSuffix()
        {
            return new SuffixResult()
            {
                Type = "Verb Root",
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMainF : $"{Input.TrPrefP} {Input.TrMainF}",
                Description = $"Basic verb form from: {Input.TrName}"
            };
        }

        public override SuffixResult GetNegationSuffix()
        {
            if (VerbProps.IsNegation)
            {
                return new SuffixResult()
                {
                    Type = "Negation Suffix",
                    Value = $"m{HarmonyInfo.AEHarmony}",
                    Description = $"m + {HarmonyInfo.AEHarmony}. According to the vowel harmony (a/e)"
                };
            }
            else
            {
                return null;
            }
        }

        public override SuffixResult GetTense0Suffix()
        {
            SuffixResult output = new()
            {
                Type = "Past Simple Tense Suffix",
                Value = $"m{HarmonyInfo.BaseHarmony}ş",
                Description = $"m + {HarmonyInfo.BaseHarmony} + ş (according to the vowel harmony)."
            };

            if (VerbProps.IsNegation)
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
        }

        public override SuffixResult GetQuestionSuffix()
        {
            string type = "Question Suffix";

            if (VerbProps.IsQuestion)
            {
                if (VerbProps.IsNegation || VerbProps.Person == 8)
                {
                    return new SuffixResult()
                    {
                        Type = type,
                        Value = $"m{HarmonyInfo.IHarmony}",
                        Description = $"Question Suffix: m + {HarmonyInfo.IHarmony}, according to the vowel harmony"
                    };
                }
                else
                {
                    return new SuffixResult()
                    {
                        Type = type,
                        Value = $"m{HarmonyInfo.BaseHarmony}",
                        Description = $"Question Suffix: m + {HarmonyInfo.BaseHarmony}, according to the vowel harmony"
                    };
                }
            }
            else
            {
                return null;
            }
        }

        public override SuffixResult GetConsonantBuffer1(string formOutput, string personSuffix)
        {
            bool isPrevVowel = VowelHelper.IsLastCharVowel(formOutput);
            bool isPostVowel = VowelHelper.IsFirstCharVowel(personSuffix);

            if (isPrevVowel && isPostVowel)
            {
                return new SuffixResult()
                {
                    Type = "Y Consonant Buffer",
                    Value = "y",
                    Description = $"'y' consonant buffer between two vowels"
                };
            }
            else
            {
                return null;
            }
        }

        public override SuffixResult GetPluralSuffix()
        {
            if (VerbProps.Person == 8)
            {
                return new SuffixResult()
                {
                    Type = "Plural Suffix",
                    Value = $"l{HarmonyInfo.AEHarmony}r",
                    Description = $"In 3rd. plural person, the plural suffix is added to the main verb word instead of the question suffix"
                };
            }

            return null;
        }

        public override SuffixResult GetPersonSuffix()
        {
            if (VerbProps.Person == 8) return null;

            char? v = VerbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

            string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            return new SuffixResult()
            {
                Type = "Person Suffix",
                Value = persons[VerbProps.Person - 1],
                Description = $"Person suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType} person"
            };
        }


    }
}
