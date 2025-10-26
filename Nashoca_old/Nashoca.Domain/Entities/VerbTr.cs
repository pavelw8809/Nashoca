using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Domain.Entities
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

    public class VerbTr
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string VtrSymbol { get; set; }

        [Required]
        [MaxLength(30)]
        public string VtrName { get; set; }
        
        [MaxLength(20)]
        public string VtrPrefP { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string VtrMainF { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string VtrMinF { get; set; }
        
        [MaxLength(1, ErrorMessage = "vtr_chg_l property should contain only 1 character")]
        public string VtrChgL { get; set; }

        [Required]
        [MaxLength(2)]
        public string VtrAoristS { get; set; }

        [Required]
        public Case VtrCase { get; set; }

        public VerbTrans VerbTrans { get; set; }
    }
}
