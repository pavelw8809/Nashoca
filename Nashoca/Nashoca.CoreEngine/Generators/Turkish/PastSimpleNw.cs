using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;

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

        public override SuffixResult GetNegationSuffix()
        {
            if (VerbProps.IsNegation)
            {
                return new SuffixResult()
                {
                    Type = "Negation Suffix",
                    TypeSymbol = "negation",
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
                TypeSymbol = "tense0",
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
                        TypeSymbol = "question",
                        Value = $"m{HarmonyInfo.IHarmony}",
                        Description = $"Question Suffix: m + {HarmonyInfo.IHarmony}, according to the vowel harmony"
                    };
                }
                else
                {
                    return new SuffixResult()
                    {
                        Type = type,
                        TypeSymbol = "question",
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
                    TypeSymbol = "consbuf",
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
                    TypeSymbol = "plural",
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
                TypeSymbol = "person",
                Value = persons[VerbProps.Person - 1],
                Description = $"Person suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType} person"
            };
        }


    }
}
