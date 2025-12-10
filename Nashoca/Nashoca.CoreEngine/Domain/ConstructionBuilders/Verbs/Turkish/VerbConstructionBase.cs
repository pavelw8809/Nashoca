using Nashoca.CoreEngine.Domain.ConstructionBuilders.Elements;
using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish
{
    public abstract class VerbConstructionBase
    {
        public abstract string ConstructionNameTr { get; }
        protected VerbInputObjTrEn Input { get; set; }
        protected HarmonyInfoObj HarmonyInfo { get; set; }
        protected FullInfoObj PrefPartFullInfo { get; set; } 

        protected VerbConstructionBase(VerbInputObjTrEn input)
        {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
            PrefPartFullInfo = input.TrIsCompound ? new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrPrefP), ConsonantInfo = ConsonantHelper.GetConsonantInfo(input.TrPrefP) } : new();
        }

        public virtual string GetConstructionName() => null;

        public virtual string GetName() => Input.TrName;

        public virtual string GetCase() => Input.TrCase;
        
        public virtual string GetFormCode(int FormNo)
        {
            string codeNo = FormNo.ToString().PadLeft(5, '0');
            return $"{Input.TrSymbol}-{Input.TransId}-{codeNo}";
        }

        public virtual SuffixResult GetNounRoot(VerbPropsObj verbProps)
        {
            INounRoot<string> nounRootInstance = new VerbConsonantNounRoot();
            SuffixResult output = nounRootInstance.GetRoot(Input.TrPrefP, PrefPartFullInfo, null);

            /*
            SuffixResult output = new()
            {
                Type = VerbAnnotations.NounSuffix,
                TypeSymbol = VerbAnnotations.NounSymbol,
                Value = null,
                Description = null
            };

            if (Input.TrMainF == "ol")
            {
                IPosessive<VerbInputObjTrEn, VerbPropsObj> possesiveForm = new VerbPossesive(Input, verbProps, PrefPartFullInfo);
                output.Value = possesiveForm.GetForm();
            }
            */

            return output;
        }

        public virtual SuffixResult GetRootSuffix(VerbPropsObj verbProps)
        {
            return new SuffixResult()
            {
                Type = VerbAnnotations.RootSuffix,
                TypeSymbol = VerbAnnotations.RootSymbol,
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMainF : $"{Input.TrPrefP} {Input.TrMainF}",
                Description = string.Format(VerbAnnotations.RootInfo, "")
            };
        }

        public virtual SuffixResult GetAbilityPreSuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.AbilityPreSuffix,
                TypeSymbol = VerbAnnotations.AbilityPreSymbol,
                Value = null,
                Description = null
            };

            if (!(verbProps.ConstructCode >= 20 && verbProps.ConstructCode <= 24)) return output;

            if (HarmonyInfo.IsLastCharVowel)
            {
                output.Value = "y";
                output.Description = VerbAnnotations.AbilityPreInfo;
            }

            return output;
        }

        public virtual SuffixResult GetAbilitySuffix(VerbPropsObj verbProps)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.AbilitySuffix,
                TypeSymbol = VerbAnnotations.AbilitySymbol,
                Value = null,
                Description = null
            };

            if (!(verbProps.ConstructCode >= 20 && verbProps.ConstructCode < 24)) return output;

            if (verbProps.IsNegation)
            {
                output.Value = $"{HarmonyInfo.AEHarmony}";
                output.Description = string.Format(VerbAnnotations.AbilityIngoNeg, HarmonyInfo.AEHarmony);
            }
            else
            {
                output.Value = $"{HarmonyInfo.AEHarmony}bil";
                output.Description = string.Format(VerbAnnotations.AbilityInfoPos, HarmonyInfo.AEHarmony);
            }

            return output;
        }

        public virtual SuffixResult GetNegationSuffix(VerbPropsObj verbProps) => new()
        {
            Type = VerbAnnotations.NegationSuffix,
            TypeSymbol = VerbAnnotations.NegationSymbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetTense0PreSuffix(VerbPropsObj verbProps) => new()
        {
            Type = VerbAnnotations.Tense0PreSuffix,
            TypeSymbol = VerbAnnotations.Tense0PreSymbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetTense0Suffix(VerbPropsObj verbProps) => new() 
        {
            Type = string.Format(VerbAnnotations.Tense0Suffix, "Default"),
            TypeSymbol = VerbAnnotations.Tense0Symbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetTense1PreSuffix() => new()
        {
            Type = VerbAnnotations.Tense1PreSuffix,
            TypeSymbol = VerbAnnotations.Tense1PreSymbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetTense1Suffix(VerbPropsObj verbProps) => new() 
        {
            Type = string.Format(VerbAnnotations.Tense1Suffix, "Default"),
            TypeSymbol = VerbAnnotations.Tense1Symbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetPluralSuffix(VerbPropsObj verbProps) => new() 
        {
            Type = VerbAnnotations.PluralSuffix,
            TypeSymbol = VerbAnnotations.PluralSymbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetQuestionSuffix(VerbPropsObj verbProps) => new()
        {
            Type = VerbAnnotations.QuestionSuffix,
            TypeSymbol = VerbAnnotations.QuestionSymbol,
            Value = null,
            Description = null
        };

        public virtual SuffixResult GetConsonantBuffer1(string formOutput, string personSuffix)
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
        public virtual SuffixResult GetTense1PostSuffix() => null;
        public virtual SuffixResult GetPersonSuffix(VerbPropsObj verbProps) => null;
        public virtual SuffixResult GetQuestionPostSuffix(VerbPropsObj verbPropsObj) => null;
    }
}
