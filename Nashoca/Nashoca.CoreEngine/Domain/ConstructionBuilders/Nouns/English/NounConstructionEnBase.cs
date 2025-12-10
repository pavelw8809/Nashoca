using Nashoca.CoreEngine.Infrastructure.Models.Nouns;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Nouns.English
{
    public abstract class NounConstructionEnBase
    {
        protected NounInputObjTrEn Input { get; set; }

        protected NounConstructionEnBase(NounInputObjTrEn input)
        {
            Input = input;
        }


    }
}
