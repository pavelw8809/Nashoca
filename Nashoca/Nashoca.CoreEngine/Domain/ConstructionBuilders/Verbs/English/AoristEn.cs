using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public class AoristEn : VerbConstructionEnBase
    {
        public override string ConstructionNameEn => "Aorist";
        public override string ConstructionDescEn => "Usually";

        public AoristEn(VerbInputObjTrEn input) : base(input)
        {
            Input = input;
        }

        public override string GetModalQuestion(VerbPropsObj verbProps)
        {
            if (verbProps.IsQuestion)
            {
                return VerbDataEn.snPersons[verbProps.Person - 1];
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
                    return VerbDataEn.snPersons[verbProps.Person - 1];
                }
                return null;
            }
        }

        public override string GetVerbForm(VerbPropsObj verbProps)
        {
            if (!verbProps.IsQuestion && !verbProps.IsNegation && verbProps.Person >= 3 && verbProps.Person <= 5) return $"{Input.EnMainF}s";
            return Input.EnMainF;
        }
    }
}
