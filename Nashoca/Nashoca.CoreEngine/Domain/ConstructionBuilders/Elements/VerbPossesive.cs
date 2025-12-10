using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;
using System.Globalization;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Elements
{
    public class VerbPossesive : IPosessive<VerbInputObjTrEn, VerbPropsObj>
    {
        protected VerbInputObjTrEn Input { get; }
        protected VerbPropsObj Props { get; }
        protected FullInfoObj NounInfo { get; }

        public VerbPossesive(VerbInputObjTrEn input, VerbPropsObj props, FullInfoObj nounInfo)
        {
            Input = input;
            Props = props;
            NounInfo = nounInfo;
        }

        public SuffixResult GetForm()
        {
            SuffixResult output = new()
            {
                Type = VerbAnnotations.NounRootSuffix,
                TypeSymbol = VerbAnnotations.NounRootSymbol,
                Value = null,
                Description = null
            };

            if (NounInfo.ConsonantInfo.VoicedEquivalent != null)
            {
                output.Value = ConsonantHelper.ReplaceLastLetter(Input.TrPrefP, NounInfo.ConsonantInfo.VoicedEquivalent);
                output.Description = string.Format(VerbAnnotations.NounRootInfoChg, Input.TrPrefP, NounInfo.ConsonantInfo.LastLetter, NounInfo.ConsonantInfo.VoicedEquivalent);
            }
            else
            {
                output.Value = Input.TrPrefP;
                output.Description = string.Format(VerbAnnotations.NounRootInfo, Input.TrPrefP);
            }

            return output;
        }
    }
}
