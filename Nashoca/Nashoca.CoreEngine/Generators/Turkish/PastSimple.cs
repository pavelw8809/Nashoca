using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public class PastSimple : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Belirli Geçmiş Zaman";

        public PastSimple(InputObjTrEn input) : base(input) { 
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
        }

        /*
        public override SuffixResult GetRootSuffix()
        {
            return new SuffixResult()
            {
                Type = "Verb Root",
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMainF : $"{Input.TrPrefP} {Input.TrMainF}",
                Description = $"Basic verb form from: {Input.TrName}"
            };
        }
        */

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
                Value = $"d{HarmonyInfo.BaseHarmony}",
                Description = $"d + {HarmonyInfo.BaseHarmony} (according to the vowel harmony)."
            };

            if (VerbProps.IsNegation)
            {
                output.Value = $"d{HarmonyInfo.IHarmony}";
                output.Description = $"d + {HarmonyInfo.IHarmony} (according to the vowel harmony).";
            }
            else
            {
                if (HarmonyInfo.IsLastCharVoiceless)
                {
                    output.Value = $"t{HarmonyInfo.BaseHarmony}";
                    output.Description = $"t + {HarmonyInfo.BaseHarmony}. The last letter is a voiceless consonant, hence 't' instead of 'd'.";
                }
                else
                {
                    output.Value = $"d{HarmonyInfo.BaseHarmony}";
                    output.Description = $"d + {HarmonyInfo.BaseHarmony} (according to the vowel harmony).";
                }
            }

            return output;
        }

        public override SuffixResult GetPersonSuffix()
        {
            char? v = VerbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

            string[] persons = ["m", "n", "", "", "", "k", $"n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            return new SuffixResult()
            {
                Type = "Person Suffix",
                Value = persons[VerbProps.Person - 1],
                Description = $"Person suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType} person"
            };
        }

        public override SuffixResult GetQuestionSuffixPost()
        {
            if (VerbProps.IsQuestion)
            {
                char? v = VerbProps.IsNegation || VerbProps.Person == 8 ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;

                return new SuffixResult()
                {
                    Type = "Question Suffix",
                    Value = $"m{v}",
                    Description = $"m + {v}, according to the vowel harmony."
                };
            }
            else
            {
                return null;
            }
        }
    }
}
