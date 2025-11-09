using Nashoca.CoreEngine.Generators.Turkish;
using Nashoca.CoreEngine.Utils;
using Nashoca.CoreEngine.Models.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nashoca.CoreEngine.Data;

namespace Nashoca.CoreEngine.Generators.English
{
    public class AbilityAoristEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Ability Mood in Aorist";
        public override string ConstructionDescEn => "";

        public AbilityAoristEn(InputObjTrEn input) : base(input)
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
        }

        public override string GetModalQuestion()
        {
            if (VerbProps.IsQuestion)
            {
                return "can";
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
                    return "cannot";
                }
                return "can";
            }
        }

        public override string GetNegation()
        {
            if (VerbProps.IsQuestion && VerbProps.IsNegation)
            {
                return "not";
            }

            return null;
        }

        public override string GetVerbForm()
        {
            return Input.EnMainF;
        }
    }
}
