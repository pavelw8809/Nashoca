using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.Interfaces
{
    internal interface IFormCatalog<T>
    {
        List<int> GetFormCatalog(T inputObj);
        List<int> GetRandomForms(Random rnd, VerbInputObjTrEn inputObj, int amount);
    }
}
