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
    public abstract class VerbConstructionEnBase
    {
        public abstract string ConstructionNameEn { get; }
        public abstract string ConstructionDescEn { get; }
        protected VerbPropsObj VerbProps { get; set; }
        protected InputObjTrEn Input { get; set; }

        protected VerbConstructionEnBase(InputObjTrEn input)
        {
            Input = input;
            VerbProps = VerbPropsHandler.GetVerbProps(input.FormNo);
        }

        public virtual string GetModalQuestion() => null;
        public virtual string GetPerson() => VerbDataEn.persons[VerbProps.Person - 1];
        public virtual string GetModal() => null;
        public virtual string GetNegation() => VerbProps.IsNegation ? "not" : null;
        public virtual string GetVerbForm() => null;
    }
}
