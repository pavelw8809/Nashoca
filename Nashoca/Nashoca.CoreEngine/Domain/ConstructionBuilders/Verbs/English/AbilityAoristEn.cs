using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public class AbilityAoristEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Ability Mood in Aorist";
        public override string ConstructionDescEn => "";

        public AbilityAoristEn(VerbInputObjTrEn input) : base(input)
        {
            Input = input;
        }

        public override string GetModalQuestion(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                return "can";
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
                    return "cannot";
                }
                return "can";
            }
        }

        public override string GetNegation(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion && verbProps.IsNegation)
            {
                return "not";
            }

            return null;
        }

        public override string GetVerbForm(VerbPropsObj verbProps)
        {
            return Input.EnMainF;
        }
    }
}
