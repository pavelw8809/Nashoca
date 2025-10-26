using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public abstract class VerbConstructionBase
    {
        public abstract string ConstructionNameTr { get; }
        protected VerbPropsObj VerbProps { get; set; }
        protected InputObjTrEn Input { get; set; }
        protected HarmonyInfoObj HarmonyInfo { get; set; }

        protected VerbConstructionBase(InputObjTrEn input)
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
        }

        public virtual VerbPropsObj GetVerbProps()
        {
            return VerbProps;
        }

        public virtual string GetConstructionName() => null;
        
        public virtual string GetFormCode()
        {
            string codeNo = Input.FormNo.ToString().PadLeft(4, '0');
            return $"{Input.TrSymbol}-{Input.TransId}-{codeNo}";
        }

        public virtual SuffixResult GetRootSuffix()
        {
            return new SuffixResult()
            {
                Type = "Verb Root",
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMainF : $"{Input.TrPrefP} {Input.TrMainF}",
                Description = $"Basic verb form from {Input.TrName}"
            };
        }

        public virtual SuffixResult GetAbilityPreSuffix()
        {
            if (VerbProps.ConstructCode >= 20 && VerbProps.ConstructCode <= 24) return null;

            if (HarmonyInfo.IsLastCharVowel) return new SuffixResult()
            {
                Type = "Y Consonant Buffer",
                Value = "y",
                Description = $"'y' consonant buffer between two vowels"
            };

            return null;
        }

        public virtual SuffixResult GetAbilitySuffix()
        {
            if (VerbProps.ConstructCode >= 20 && VerbProps.ConstructCode < 24) return null;

            string value = $"{HarmonyInfo.AEHarmony}bil";
            string desc = $"The ability suffix in affirmative sentences";

            if (VerbProps.IsNegation)
            {
                value = $"{HarmonyInfo.AEHarmony}";
                desc = $"The ability suffix in negative sentences";
            }

            return new SuffixResult()
            {
                Type = "Ability Suffix",
                Value = value,
                Description = desc
            };
        }

        public virtual SuffixResult GetNegationSuffix() => null;
        //public virtual SuffixResult GetConsonantBuffer0() => null;
        public virtual SuffixResult GetTense0PreSuffix() => null;
        public virtual SuffixResult GetTense0Suffix() => null;
        public virtual SuffixResult GetTense1PreSuffix() => null;
        public virtual SuffixResult GetTense1Suffix() => null;
        public virtual SuffixResult GetPluralSuffix() => null;
        public virtual SuffixResult GetQuestionSuffix() => null;
        public virtual SuffixResult GetConsonantBuffer1(string outputForm, string personSuffix)
        {
            if (string.IsNullOrWhiteSpace(personSuffix)) return null;

            bool isPrevVowel = VowelHelper.IsLastCharVowel(outputForm);
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
        public virtual SuffixResult GetTense1PostSuffix() => null;
        public virtual SuffixResult GetPersonSuffix() => null;
        public virtual SuffixResult GetQuestionSuffixPost() => null;
    }
}
