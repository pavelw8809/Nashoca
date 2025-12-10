using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
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
    public class VerbConsonantNounRoot : INounRoot<string>
    {
        public SuffixResult GetRoot(string input, FullInfoObj info, NounPropsObj props = null)
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.NounRootSuffix,
                TypeSymbol = VerbAnnotations.NounRootSymbol,
                Value = null,
                Description = null
            };

            if (info.ConsonantInfo.VoicedEquivalent != null)
            {
                output.Value = ConsonantHelper.ReplaceLastLetter(input, info.ConsonantInfo.VoicedEquivalent);
                output.Description = string.Format(VerbAnnotations.NounRootInfoChg, input, info.ConsonantInfo.LastLetter, info.ConsonantInfo.VoicedEquivalent);
            }
            else
            {
                output.Value = input;
                output.Description = string.Format(VerbAnnotations.NounRootInfo, input);
            }

            return output;
        }
    }
}
