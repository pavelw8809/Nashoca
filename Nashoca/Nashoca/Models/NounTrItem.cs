using System.ComponentModel.DataAnnotations;

namespace Nashoca.Models
{
    public class NounTrItem
    {
        [Required]
        public string? NtrSymbol { get; set; }
        public string? NtrName { get; set; }
        public string? NtrPrefP { get; set; }
        public string? NtrMainF { get; set; }
        public string? NtrAccS { get; set; }
        public bool NtrIsB { get; set; }
        public bool NtrIsPl { get; set; }
        public string? NenSingF { get; set; }
        public string? NenPlurF { get; set; }
    }
}
