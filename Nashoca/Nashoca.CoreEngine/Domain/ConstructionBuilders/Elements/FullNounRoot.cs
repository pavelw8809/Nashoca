using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Nouns;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Elements
{
    public class FullNounRoot : INounRoot<NounInputObjTrEn>
    {
        public SuffixResult GetRoot(NounInputObjTrEn input, FullInfoObj info, NounPropsObj props)
        {
            string root = string.IsNullOrWhiteSpace(input.TrPrefP) ? input.TrMainF : $"{input.TrPrefP} {input.TrMainF}";

            SuffixResult output = new()
            {
                Type = NounAnnotations.RootSuffix,
                TypeSymbol = NounAnnotations.RootSymbol,
                Value = root,
                Description = VerbAnnotations.RootInfo
            };

            /*
            if (input.TrMainF.EndsWith($"s{info.HarmonyInfo.BaseHarmony} && props.PossesivePersonNumber == 0 || !props.IsPlural)
            {
                Console.WriteLine("possesive person = 0 or is not plural");
                return output;
            }
            */

            if (input.TrDefS.StartsWith("-") && (props.PossesivePersonNumber != 0 || props.IsPlural))
            {
                Console.WriteLine("defs starts from -");
                string accS = input.TrDefS.Replace("-", "");
                output.Value = $"{root}{accS}";
                output.Description = string.Format(NounAnnotations.RootInfoExc, root, input.TrDefS);
                Console.WriteLine($"Value: {output.Value}");
                return output;
            }

            if ((props.PossesivePersonNumber != 0 || props.PersonNumber != 0 || props.IsPlural) && input.TrMainF.EndsWith($"s{info.HarmonyInfo.BaseHarmony}") && input.TrMainF.Length > 2)
            {
                Console.WriteLine("root ends on si");
                output.Value = root[..^2];
                output.Description = string.Format(NounAnnotations.RootInfoDef, root, $"s{info.HarmonyInfo.BaseHarmony}");
                Console.WriteLine($"Value: {output.Value}");
                return output;
            }

            if (props.PossesivePersonNumber != 0 && !props.IsPlural && input.TrIsVowelDropping && !info.HarmonyInfo.IsLastCharVowel)
            {
                Console.WriteLine("root is plural & vowel is dropping & last vowel");
                output.Value = StringHelper.RemoveLetterFromEnd(root, 2);
                output.Description = string.Format(NounAnnotations.RootInfoVowelDrop, root);
                Console.WriteLine($"Value: {output.Value}");
                return output;
            }

            Console.WriteLine($"noun2: {root} -> icc. {input.TrIsConsonantChanged} -  pn. {props.PossesivePersonNumber} - ispl. {props.IsPlural} - ispospl. {props.IsPossesivePersonPlural} - ispp. {props.IsPersonPlural}");

            if (props.PossesivePersonNumber != 0 && !props.IsPlural && input.TrIsConsonantChanged)
            {
                Console.WriteLine("root is plural & consonant is changing");
                char? voicedConsonant = ConsonantHelper.GetVoicedConsonant(info.ConsonantInfo.LastLetter);
                output.Value = ConsonantHelper.ReplaceLastLetter(root, voicedConsonant);
                output.Description = string.Format(NounAnnotations.RootInfoChg, root, info.ConsonantInfo.LastLetter, voicedConsonant);
                Console.WriteLine($"Value: {output.Value}");
                return output;  
            }

            Console.WriteLine("the rest");
            Console.WriteLine($"Value: {output.Value}");
            return output;
        }
    }
}
