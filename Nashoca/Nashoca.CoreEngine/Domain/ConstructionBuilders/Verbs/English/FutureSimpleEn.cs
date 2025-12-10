using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public class FutureSimpleEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Future Simple";
        public override string ConstructionDescEn => "Plans and actions in the future";
        public FutureSimpleEn(VerbInputObjTrEn input) : base(input) {
            Input = input;
        }

        public override string GetModalQuestion(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                return VerbDataEn.futureModal;
            }
            else
            {
                return null;
            }
        }

        public override string GetModal(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                return null;
            }
            else
            {
                return VerbDataEn.futureModal;
            }
        }

        public override string GetVerbForm(VerbPropsObj verbProps)
        {
            //if (VerbProps.IsQuestion || VerbProps.IsNegation) return $"{Input.EnMainF}";
            return Input.EnMainF;
        }
    }
}
