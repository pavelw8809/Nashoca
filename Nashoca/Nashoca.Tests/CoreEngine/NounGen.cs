using Nashoca.CoreEngine.Domain.ConstructionBuilders.Elements;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using Nashoca.Domain.Entities;
using Nashoca.Tests.Helpers;

namespace Nashoca.Tests.CoreEngine
{
    public class NounGen
    {
        public static IEnumerable<object[]> GetTestData()
        {
            var projectDir = AppContext.BaseDirectory;
            var nounTrList = FileHandler.GetCsvData<NounTr>(Path.Combine(projectDir, "CoreEngine", "TestData", "NounTr.csv"));

            foreach (var nounTr in nounTrList)
            {
                NounInputObjTrEn nounObj = new()
                {
                    TrSymbol = nounTr.Symbol,
                    TrName = nounTr.Name,
                    TrPrefP = nounTr.PrefP,
                    TrMainF = nounTr.MainF,
                    TrDefS = nounTr.DefS,
                    TrIsVowelDropping = nounTr.IsVd,
                    TrIsConsonantChanged = nounTr.IsCc,
                    TrIsPredicative = nounTr.IsB,
                    TrIsVar = nounTr.IsH,
                    TrIsPossesive = nounTr.IsP,
                    TrIsPlural = nounTr.IsPl,
                    TrIsCase = nounTr.IsC,
                    TrIsCasePossesive = nounTr.IsCP,
                    TrIsPredicativePossesive = nounTr.IsBP,
                    TrIsVarPossesive = nounTr.IsHP,
                    TrIsDative = nounTr.IsDative,
                    EnPrefP = " ",
                    EnMainF = " ",
                    EnNamePlural = " ",
                    TransId = nounTr.Id
                };

                yield return new object[] { nounObj };
            }
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void NounConstruction_GenerateRoot_IsValidOutput(NounInputObjTrEn testObj)
        {
            var rootGen = new FullNounRoot();

            List<int> formList = [
                0, 100, 10, 20, 110, 120, 1, 2, 201, 301, 401
            ];

            List<(string Name, string Expected, int FormNo)> expectedForms = new()
            {
                ("saat", "saat", 0),
                ("saat", "saat", 100),
                ("saat", "saat", 10),
                ("saat", "saat", 80),
                ("saat", "saat", 110),
                ("saat", "saat", 120),
                ("saat", "saat", 8010),
                ("saat", "saat", 8080),
                ("saat", "saat", 8180),
                ("bıçak", "bıçak", 0),
                ("bıçak", "bıçak", 100),
                ("bıçak", "bıçağ", 10),
                ("bıçak", "bıçağ", 80),
                ("bıçak", "bıçak", 110),
                ("bıçak", "bıçak", 120),
                ("bıçak", "bıçağ", 8010),
                ("bıçak", "bıçağ", 8080),
                ("bıçak", "bıçak", 8180),
                ("şehir", "şehir", 0),
                ("şehir", "şehir", 100),
                ("şehir", "şehr", 10),
                ("şehir", "şehr", 80),
                ("şehir", "şehir", 110),
                ("şehir", "şehir", 120),
                ("şehir", "şehr", 8010),
                ("şehir", "şehr", 8080),
                ("şehir", "şehir", 8180),
                ("vücut", "vücut", 0),
                ("vücut", "vücut", 100),
                ("vücut", "vücud", 10),
                ("vücut", "vücud", 80),
                ("vücut", "vücut", 110),
                ("vücut", "vücut", 120),
                ("vücut", "vücud", 8010),
                ("vücut", "vücud", 8080),
                ("vücut", "vücut", 8180),
                ("hesap makinesi", "hesap makinesi", 0),
                ("hesap makinesi", "hesap makine", 100),
                ("hesap makinesi", "hesap makine", 10),
                ("hesap makinesi", "hesap makine", 80),
                ("hesap makinesi", "hesap makine", 110),
                ("hesap makinesi", "hesap makine", 120),
                ("hesap makinesi", "hesap makine", 8010),
                ("hesap makinesi", "hesap makine", 8080),
                ("hesap makinesi", "hesap makine", 8180),
                ("mektup", "mektup", 0),
                ("mektup", "mektup", 100),
                ("mektup", "mektub", 10),
                ("mektup", "mektub", 80),
                ("mektup", "mektup", 110),
                ("mektup", "mektup", 120),
                ("mektup", "mektub", 8010),
                ("mektup", "mektub", 8080),
                ("mektup", "mektup", 8180),
                ("doktor", "doktor", 0),
                ("doktor", "doktor", 100),
                ("doktor", "doktor", 10),
                ("doktor", "doktor", 80),
                ("doktor", "doktor", 110),
                ("doktor", "doktor", 120),
                ("doktor", "doktor", 1),
                ("doktor", "doktor", 2),
                ("doktor", "doktor", 201),
                ("doktor", "doktor", 301),
                ("doktor", "doktor", 401),
                ("doktor", "doktor", 8010),
                ("doktor", "doktor", 8080),
                ("doktor", "doktor", 8180),
                ("araba", "araba", 0),
                ("araba", "araba", 100),
                ("araba", "araba", 10),
                ("araba", "araba", 80),
                ("araba", "araba", 110),
                ("araba", "araba", 120),
                ("araba", "araba", 8010),
                ("araba", "araba", 8080),
                ("araba", "araba", 8180),
                ("su", "su", 0),
                ("su", "suyu", 100),
                ("su", "suyu", 10),
                ("su", "suyu", 80),
                ("su", "suyu", 110),
                ("su", "suyu", 120),
                ("su", "suyu", 8010),
                ("su", "suyu", 8080),
                ("su", "suyu", 8180),
                ("su tesisatçısı", "su tesisatçısı", 0),
                ("su tesisatçısı", "su tesisatçı", 1),
                ("su tesisatçısı", "su tesisatçı", 2),
                ("su tesisatçısı", "su tesisatçı", 3),
                ("su tesisatçısı", "su tesisatçı", 100),
                ("su tesisatçısı", "su tesisatçı", 101),
                ("su tesisatçısı", "su tesisatçısı", 201),
                ("su tesisatçısı", "su tesisatçısı", 301),
                ("su tesisatçısı", "su tesisatçısı", 401),
                ("su tesisatçısı", "su tesisatçısı", 8000),
                ("su tesisatçısı", "su tesisatçı", 8010),
                ("su tesisatçısı", "su tesisatçı", 8100),
                ("su tesisatçısı", "su tesisatçı", 8030),
                ("su tesisatçısı", "su tesisatçı", 9010),
            };

            List<(string Name, string Expected, int FormNo)> testForms = expectedForms.Where(x => x.Name == testObj.TrName).ToList();

            Assert.All(testForms, form =>
            {
                NounPropsObj nounPropsObj = NounPropsHandler.GetNounProps(form.FormNo);
                FullInfoObj fullInfoObj = new() { HarmonyInfo = VowelHelper.GetHarmonyInfo(testObj.TrName), ConsonantInfo = ConsonantHelper.GetConsonantInfo(testObj.TrName, testObj.TrDefS) };
                SuffixResult root = rootGen.GetRoot(testObj, fullInfoObj, nounPropsObj);

                Assert.Equal(form.Expected, root.Value);
            });
        }
    }
}
