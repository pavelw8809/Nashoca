using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;

namespace Nashoca.CoreEngine.Domain.Generators.Verbs
{
    internal class VerbFormCatalog : IFormCatalog<VerbInputObjTrEn>
    {
        public List<int> GetFormCatalog(VerbInputObjTrEn inputObj) {
            List<int> formList = new();

            if (inputObj.TrIsPersonal)
            {
                formList.AddRange(VerbCatalogIndex.personalForms);
            }

            if (inputObj.TrIsNotPersonal)
            {
                formList.AddRange(VerbCatalogIndex.nonPersonalForms);
            }

            if (inputObj.TrIsFormal)
            {
                formList.AddRange(VerbCatalogIndex.formalForms);
            }

            return formList;
        }

        public List<int> GetRandomForms(Random rnd, VerbInputObjTrEn inputObj, int amount)
        {
            List<int> formList = new();

            List<int> getAllForms = GetFormCatalog(inputObj);
            var arr = getAllForms.ToArray();
            int n = arr.Length;
            for (int i = 0; i < amount; i++)
            {
                int k = rnd.Next(i, n);
                (arr[i], arr[k]) = (arr[k], arr[i]);
            }
            return arr.Take(amount).ToList();
        }
    }
}
