namespace Nashoca.CoreEngine.Models.Verbs
{
    public class InputObjTrEnCollection
    {
        public int GroupId { get; set; }
        public IEnumerable<InputObjTrEn>GroupItems { get; set; } = [];
    }
}