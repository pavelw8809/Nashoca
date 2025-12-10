namespace Nashoca.CoreEngine.Infrastructure.Models.Verbs
{
    public class VerbInputObjTrEnCollection
    {
        public int GroupId { get; set; }
        public IEnumerable<int>GroupItems { get; set; } = [];
    }
}