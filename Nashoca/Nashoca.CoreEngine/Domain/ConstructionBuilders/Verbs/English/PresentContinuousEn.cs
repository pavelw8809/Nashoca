using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public class PresentContinuousEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Present Continuous";
        public override string ConstructionDescEn => "At this time";

        public PresentContinuousEn(VerbInputObjTrEn input) : base(input) 
        {
            Input = input;
        }
        public override string GetModalQuestion(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                if (string.IsNullOrWhiteSpace(Input.EnContF))
                {
                    return VerbDataEn.snPersons[verbProps.Person - 1];
                }
                return VerbDataEn.cPersons[verbProps.Person - 1];
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
                if (string.IsNullOrWhiteSpace(Input.EnContF))
                {
                    if (verbProps.IsNegation)
                    {
                        return VerbDataEn.snPersons[verbProps.Person - 1];
                    }
                    return null;
                }
                return VerbDataEn.cPersons[verbProps.Person - 1];
            }
        }

        public override string GetVerbForm(VerbPropsObj verbProps)
        {
            if (string.IsNullOrEmpty(Input.EnContF))
            {
                if (!verbProps.IsQuestion && !verbProps.IsNegation && verbProps.Person >= 3 && verbProps.Person <= 5) return $"{Input.EnMainF}s";
                return Input.EnMainF;
            }
            else
            {
                return $"{Input.EnContF}ing";
            }
        }
    }
}
