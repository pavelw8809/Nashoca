using Nashoca.CoreEngine.Data;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (VerbProps.IsNegation)
                {
                    return VerbDataEn.futureModal;
                }
                return null;
            }
        }

        public override string GetVerbForm()
        {
            //if (VerbProps.IsQuestion || VerbProps.IsNegation) return $"{Input.EnMainF}";
            return Input.EnMainF;
        }
    }
}
