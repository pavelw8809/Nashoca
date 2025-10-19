using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public class Aorist : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Geniş Zaman";

        public Aorist(InputObjTrEn input) : base (input)
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
        }

        public override SuffixResult GetRootSuffix()
        {
            string value = Input.TrMinF;
            string desc = $"Basic verb form from: {Input.TrName}";

            if (VerbProps.IsNegation)
            {
                value = Input.TrMainF;
            }

            return new SuffixResult()
            {
                Type = "Verb Root",
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? value : $"{Input.TrPrefP} {value}",
                Description = desc
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
            string suffixName = "Aorist Tense Suffix";

            SuffixResult output = new SuffixResult()
            {
                Type = suffixName,
                Value = $"", //\u2205,
                Description = $"Empty Aorist tense suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType}"
            };

            if (VerbProps.IsNegation)
            {
                if ((VerbProps.Person != 1 && VerbProps.Person != 6) || VerbProps.IsQuestion)
                {
                    output.Value = "z";
                    output.Description = $"\'z\' Aorist negation tense suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType}";
                }
            }
            else
            {
                output.Value = Input.TrAoS;
                output.Description = $"\'{Input.TrAoS}\' Aorist tense suffix";
            }

            return output;
        }

        /*
        public SuffixResult GetTense1PreSuffix()
        {
            return null;
        }
        */

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
            if (string.IsNullOrWhiteSpace(personSuffix)) return null;

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
            if (VerbProps.IsQuestion && VerbProps.Person == 8)
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
            char? v = VerbProps.IsNegation ? HarmonyInfo.IHarmony : HarmonyInfo.BaseHarmony;
            string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];
            string[] nPersons = ["m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            if (VerbProps.IsQuestion && VerbProps.Person == 8) return null;

            SuffixResult output = new()
            {
                Type = "Person Suffix",
                Value = persons[VerbProps.Person - 1],
                Description = $"Person suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType} person",
            };

            if (VerbProps.IsNegation && !VerbProps.IsQuestion)
            {
                output.Value = nPersons[VerbProps.Person - 1];
            }

            return output;
        }
    }
}
