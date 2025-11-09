using Nashoca.CoreEngine.Data;
using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.English
{
    public class AoristEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Aorist";
        public override string ConstructionDescEn => "Usually";

        public AoristEn(InputObjTrEn input) : base(input)
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
        }

        public override string GetModalQuestion()
        {
            if (VerbProps.IsQuestion)
            {
                return VerbDataEn.snPersons[VerbProps.Person - 1];
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
                    return VerbDataEn.snPersons[VerbProps.Person - 1];
                }
                return null;
            }
        }

        public override string GetVerbForm()
        {
            if (!VerbProps.IsQuestion && !VerbProps.IsNegation && (VerbProps.Person >= 3 && VerbProps.Person <= 5)) return $"{Input.EnMainF}s";
            return Input.EnMainF;
        }
    }
}
