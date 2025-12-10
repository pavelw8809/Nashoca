namespace Nashoca.CoreEngine.Infrastructure.Models.Nouns
{
    public class NounPropsObj
    {
        public bool IsPlural { get; set; }
        public int Case { get; set; }
        public int PossesivePersonNumber { get; set; }
        public bool IsPossesivePersonPlural { get; set; }
        public int Person { get; set; }
        public int PersonNumber { get; set; }
        public string PersonType { get; set; }
        public bool IsPersonPlural { get; set; }
        public bool IsNegation { get; set; }
        public bool IsQuestion { get; set; }
        public int ConstructCode { get; set; }
    }
}
