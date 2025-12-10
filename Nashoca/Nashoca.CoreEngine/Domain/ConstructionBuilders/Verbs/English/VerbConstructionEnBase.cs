using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English
{
    public abstract class VerbConstructionEnBase
    {
        public abstract string ConstructionNameEn { get; }
        public abstract string ConstructionDescEn { get; }
        protected VerbInputObjTrEn Input { get; set; }

        protected VerbConstructionEnBase(VerbInputObjTrEn input)
        {
            Input = input;
        }

        public virtual string GetName() => Input.EnMainF;
        public virtual string GetModalQuestion(VerbPropsObj verbProps) => null;
        public virtual string GetPerson(VerbPropsObj verbProps) => VerbDataEn.persons[verbProps.Person - 1];
        public virtual string GetModal(VerbPropsObj verbProps) => null;
        public virtual string GetNegation(VerbPropsObj verbProps) => verbProps.IsNegation ? "not" : null;
        public virtual string GetVerbForm(VerbPropsObj verbProps) => null;
    }
}
