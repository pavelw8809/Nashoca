using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Models
{
    public class VerbEn
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string VenSymbol { get; set; }

        [Required]
        [MaxLength(30)]
        public string VenName { get; set; }

        [Required]
        [MaxLength(30)]
        public string VenMainF { get; set; }

        [Required]
        [MaxLength(30)]
        public string VenMinF { get; set; }

        [Required]
        [MaxLength(30)]
        public string VenPastF { get; set; }

        [Required]
        [MaxLength(30)]
        public string VenPpastF { get; set; }

        [MaxLength(10)]
        public string VenAdd { get; set; }

        public int? VenExc { get; set; }

        public VerbTrans VerbTrans { get; set; }
    }
}
