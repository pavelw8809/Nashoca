using System.Reflection.Metadata;

namespace Nashoca.CoreEngine.Infrastructure.Models.Nouns
{
    public class NounInputObjTrEn
    {
        public string TrSymbol { get; set; }
        public string TrName { get; set; }
        public string TrPrefP { get; set; }
        public string TrMainF { get; set; }
        public string TrDefS { get; set; }
        public bool TrIsVowelDropping { get; set; }
        public bool TrIsConsonantChanged { get; set; }
        public bool TrIsPredicative { get; set; }
        public bool TrIsVar { get; set; }
        public bool TrIsPossesive { get; set; }
        public bool TrIsPlural { get; set; }
        public bool TrIsCase { get; set; }
        public bool TrIsCasePossesive { get; set; }
        public bool TrIsPredicativePossesive { get; set; }
        public bool TrIsVarPossesive { get; set; }
        public bool TrIsDative { get; set; }
        public string EnPrefP { get; set; }
        public string EnMainF { get; set; }
        public string EnNamePlural { get; set; }
        public int TransId { get; set; }
    }
}

//Id,Symbol,Name,PrefP,MainF,AccF,IsB,IsH,IsP,IsPl,IsC,IsCP,IsBP,IsHP