using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Models
{
    public class NounTr
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string NtrSymbol { get; set; }

        [Required]
        [MaxLength(30)]
        public string NtrName { get; set; }

        [Required]
        [MaxLength(30)]
        public string NtrPrefP { get; set; }

        [Required]
        [MaxLength(30)]
        public string NtrMainF { get; set; }

        [Required]
        [MaxLength(30)]
        public string NtrAccS { get; set; }

        [Required]
        public bool NtrIsB { get; set; }

        [Required]
        public bool NtrIsPl { get; set; }

        [Required]
        [MaxLength(30)]
        public string NenSingF { get; set; }

        [Required]
        [MaxLength(30)]
        public string NenPlurF { get; set; }
    }
}
