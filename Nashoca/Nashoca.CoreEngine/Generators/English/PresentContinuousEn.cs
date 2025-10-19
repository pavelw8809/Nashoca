using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using Nashoca.CoreEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Generators.English
{
    public class PresentContinuousEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Present Continuous";
        public override string ConstructionDescEn => "At this time";

        public PresentContinuousEn(InputObjTrEn input) : base(input) 
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo); ;
        }
        public override string GetModalQuestion()
        {
            if (VerbProps.IsQuestion)
            {
                if (string.IsNullOrWhiteSpace(Input.EnContF))
                {
                    return VerbDataEn.snPersons[VerbProps.Person - 1];
                }
                return VerbDataEn.cPersons[VerbProps.Person - 1];
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
                if (string.IsNullOrWhiteSpace(Input.EnContF))
                {
                    if (VerbProps.IsNegation)
                    {
                        return VerbDataEn.snPersons[VerbProps.Person - 1];
                    }
                    return null;
                }
                return VerbDataEn.cPersons[VerbProps.Person - 1];
            }
        }

        public override string GetVerbForm()
        {
            if (string.IsNullOrEmpty(Input.EnContF))
            {
                if (!VerbProps.IsQuestion && !VerbProps.IsNegation && (VerbProps.Person >= 3 && VerbProps.Person <= 5)) return $"{Input.EnMainF}s";
                return Input.EnMainF;
            }
            else
            {
                return $"{Input.EnContF}ing";
            }
        }
    }
}
