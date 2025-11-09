using Nashoca.CoreEngine.Data;
using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Utils;

namespace Nashoca.CoreEngine.Generators.English
{
    public class FutureSimpleEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Future Simple";
        public override string ConstructionDescEn => "Plans and actions in the future";
        public FutureSimpleEn(InputObjTrEn input) : base(input) {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
        }

        public override string GetModalQuestion()
        {
            if (VerbProps.IsQuestion)
            {
                return VerbDataEn.futureModal;
            }
            else
            {
                return null;
            }
        }

        public override string GetModal()
        {
            if (VerbProps.IsQuestion)
            {
                return null;
            }
            else
            {
                return VerbDataEn.futureModal;
            }
        }

        public override string GetVerbForm()
        {
            //if (VerbProps.IsQuestion || VerbProps.IsNegation) return $"{Input.EnMainF}";
            return Input.EnMainF;
        }
    }
}
