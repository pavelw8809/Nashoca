using Nashoca.CoreEngine.Infrastructure.Models.Main;

namespace Nashoca.CoreEngine.Infrastructure.Models.Nouns
{
    public class NounOutputObjTrEn
    {
        public string Type { get; set; }
        public string FormCode { get; set; }
        public string Name { get; set; }
        public string FormName { get; set; }
        public string IsPlural { get; set; }
        public string IsFormal { get; set; }
        public string Person { get; set; }
        public string ConstructionNameTr { get; set; }
        public ICollection<SuffixResult> SuffixResults { get; set; }
        public EnTranslationInfo EnTranslation { get; set; }
    }
}
