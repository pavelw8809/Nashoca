using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public class PresentContinuous : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Şimdiki Zaman";
        public PresentContinuous(InputObjTrEn input) : base (input)
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
                Type = "Verb Root",
                TypeSymbol = "root",
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
                    TypeSymbol = "negation",
                    Value = "m",
                    Description = $"Adding only m as the present continuous tense suffix starts from a vowel"
                };
            }
            else
            {
                return null;
            }
        }

        public override SuffixResult GetTense0Suffix()
        {
            SuffixResult output = new SuffixResult()
            {
                Type = "Present Continuous Tense Suffix",
                TypeSymbol = "tense0",
                Value = "yor",
                Description = $"Basic Present Continuous tense suffix"
            };

            if (VerbProps.IsNegation)
            {
                //char? harmonyVowel = VowelHelper.GetBasicVowelHarmony(input.TrWordInput);
                output.Value = $"{HarmonyInfo.BaseHarmony}yor";
                output.Description = $"Harmony vowel: {HarmonyInfo.BaseHarmony} + yor";
            }
            else
            {
                if (!HarmonyInfo.IsLastCharVowel)
                {
                    output.Value = $"{HarmonyInfo.BaseHarmony}yor";
                    output.Description = $"Harmony vowel: {HarmonyInfo.BaseHarmony} + yor";
                }
            }

            return output;
        }

        public override SuffixResult GetQuestionSuffix()
        {
            if (VerbProps.IsQuestion)
            {
                string type = "Question Suffix";
                if (VerbProps.Person == 8)
                {
                    return new SuffixResult()
                    {
                        Type = type,
                        TypeSymbol = "question",
                        Value = "mı",
                        Description = $"Question Suffix: m + u, according to the vowel harmony"
                    };
                } 
                else
                {
                    return new SuffixResult()
                    {
                        Type = type,
                        TypeSymbol = "question",
                        Value = $"mu",
                        Description = $"Question Suffix: m + u, according to the vowel harmony"
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
                    Value = "lar",
                    Description = $"In 3rd. plural person, the plural suffix is added to the main verb word instead of the question suffix"
                };
            }

            return null;
        }

        public override SuffixResult GetPersonSuffix()
        {
            if (VerbProps.Person == 8) return null;

            string[] persons = ["um", "sun", "", "", "", "uz", "sunuz", "lar"];

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
