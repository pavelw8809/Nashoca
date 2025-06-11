using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel.DataAnnotations;

namespace Nashoca.Models
{
    public enum Case
    {
        nom, // *
        acc, // i
        gen, // in
        dat, // e
        loc, // de
        abl, // den
        ins, // le
    }

    public class VerbTrItem
    {
        [Required]
        public string? VtrSymbol { get; set; }
        [Required]
        public string? VtrName { get; set; }
        public string? VtrPrefP { get; set; }
        [Required]
        public string? VtrMainF { get; set; }
        [Required]
        public string? VtrMinF { get; set; }
        [MaxLength(1, ErrorMessage = "vtr_chg_l property should contain only 1 character")]
        public char VtrChgL { get; set; }
        public string? VtrAoristS { get; set; }
        public Case VtrCase { get; set; }
    }
}
