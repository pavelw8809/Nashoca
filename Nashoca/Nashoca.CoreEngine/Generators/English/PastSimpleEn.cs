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
    public class PastSimpleEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Past Simple";
        public override string ConstructionDescEn => "Finished action in the past";
        public PastSimpleEn(InputObjTrEn input) : base(input) 
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
        }

        public override string GetModalQuestion()
        {
            if (VerbProps.IsQuestion)
            {
                return VerbDataEn.pastModal;
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
                    return VerbDataEn.pastModal;
                }
                return null;
            }
        }

        public override string GetVerbForm()
        {
            if (VerbProps.IsQuestion || VerbProps.IsNegation) return $"{Input.EnMainF}";
            return Input.EnPastF;
        }
    }
}
