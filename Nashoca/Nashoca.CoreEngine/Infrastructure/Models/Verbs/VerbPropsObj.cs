namespace Nashoca.CoreEngine.Infrastructure.Models.Verbs
{
    public class VerbPropsObj
    {
        public int ConstructCode { get; set; }
        public bool IsNegation { get; set; }
        public bool IsQuestion { get; set; }
        public int Person { get; set; }
        public int PersonNumber { get; set; }
        public bool IsPlural { get; set; }
        public bool IsFormal { get; set; }
        public string PersonType { get; set; }
    }
}
