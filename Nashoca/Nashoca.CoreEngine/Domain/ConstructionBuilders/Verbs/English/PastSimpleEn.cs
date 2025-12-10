using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public class PastSimpleEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Past Simple";
        public override string ConstructionDescEn => "Finished action in the past";
        public PastSimpleEn(VerbInputObjTrEn input) : base(input) 
        {
            Input = input;
        }

        public override string GetModalQuestion(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                return VerbDataEn.pastModal;
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
                if (verbProps.IsNegation)
                {
                    return VerbDataEn.pastModal;
                }
                return null;
            }
        }

        public override string GetVerbForm(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion || verbProps.IsNegation) return $"{Input.EnMainF}";
            return Input.EnPastF;
        }
    }
}
