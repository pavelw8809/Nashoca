using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Models
{
    public class VerbTrans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string VtId { get; set; }

        [Required]
        [MaxLength(30)]
        public string VtEn {  get; set; }

        [MaxLength(30)]
        public string VtGr { get; set; }

        [MaxLength(30)]
        public string VtPl { get; set; }

        [MaxLength(30)]
        public string VtRu { get; set; }

        [MaxLength(30)]
        public string VtTr { get; set; }

        [Required]
        [ForeignKey("VerbTr")]
        public string VtrSymbol { get; set; }
        public VerbTr VerbTr { get; set; }

        [Required]
        [ForeignKey("VerbEn")]
        public string VenSymbol { get; set; }
        public VerbEn VerbEn { get; set; }
    }
}
