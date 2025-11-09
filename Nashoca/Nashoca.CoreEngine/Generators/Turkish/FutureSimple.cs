using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public class FutureSimple : VerbConstructionBase
    {
        public override string ConstructionNameTr => "Gelecek Zaman";

        public FutureSimple(InputObjTrEn input) : base(input) {
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
                    Value = $"m{HarmonyInfo.AEHarmony}",
                    Description = $"m + {HarmonyInfo.AEHarmony}. According to the vowel harmony (a/e)"
                };
            }
            else
            {
                return null;
            }
        }

        public override SuffixResult GetTense0PreSuffix()
        {
            if (VerbProps.IsNegation || HarmonyInfo.IsLastCharVowel)
            {
                return new SuffixResult()
                {
                    Type = "Y Consonant Buffer",
                    TypeSymbol = "tense0pre",
                    Value = "y",
                    Description = $"'y' consonant buffer between two vowels"
                };
            }

            return null;
        }

        public override SuffixResult GetTense0Suffix()
        {
            string v = $"{HarmonyInfo.AEHarmony}";
            string value = !VerbProps.IsQuestion && (VerbProps.Person == 1 || VerbProps.Person == 6) ? $"{v}c{v}ğ" : $"{v}c{v}k";
            string desc = !VerbProps.IsQuestion && (VerbProps.Person == 1 || VerbProps.Person == 6) ? $"'k' changes to 'ğ' because the next suffix person starts from a vowel" : $"Basic Future Simple tense suffix";
            
            /*
            if (!VerbProps.IsQuestion && (VerbProps.Person == 1 || VerbProps.Person == 6))
            {
                value = $"{v}c{v}ğ";
                desc = $"'k' changes to 'ğ' because the next suffix person starts from a vowel";
            }
            */

            return new SuffixResult()
            {
                Type = "Future Simple Tense Suffix",
                TypeSymbol = "tense0",
                Value = value,
                Description = desc
            };
        }

        public override SuffixResult GetQuestionSuffix()
        {
            if (VerbProps.IsQuestion)
            {
                //if (VerbProps.Person == 8) return null;

                return new SuffixResult()
                {
                    Type = "Question Suffix",
                    TypeSymbol = "question",
                    Value = $"m{HarmonyInfo.IHarmony}",
                    Description = $"Question Suffix: m + {HarmonyInfo.IHarmony}, according to the vowel harmony"
                };
            }

            return null;
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
            if (VerbProps.IsQuestion && VerbProps.Person == 8)
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
            char? v = HarmonyInfo.IHarmony;
            string[] persons = [$"{v}m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];
            //string[] nPersons = ["m", $"s{v}n", "", "", "", $"{v}z", $"s{v}n{v}z", $"l{HarmonyInfo.AEHarmony}r"];

            if (VerbProps.IsQuestion && VerbProps.Person == 8) return null;

            SuffixResult output = new()
            {
                Type = "Person Suffix",
                TypeSymbol = "person",
                Value = persons[VerbProps.Person - 1],
                Description = $"Person suffix for {VerbProps.PersonNumber}. {VerbProps.PersonType} person",
            };

            /*
            if (VerbProps.IsNegation && !VerbProps.IsQuestion)
            {
                output.Value = nPersons[VerbProps.Person - 1];
            }
            */

            return output;
        }
    }
}
