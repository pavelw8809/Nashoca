using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Domain.Entities
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

        [MaxLength(30)]
        public string VenPrefP { get; set; }

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

        [MaxLength(20)]
        public string VenExc { get; set; }

        public VerbTrans VerbTrans { get; set; }
    }
}
