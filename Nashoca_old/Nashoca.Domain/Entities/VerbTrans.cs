using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nashoca.Domain.Entities
{
    public class VerbTrans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string VtId { get; set; }

        [Required]
        [MaxLength(30)]
        [ForeignKey("VerbEn")]
        public string VtEn {  get; set; }
        public VerbEn VerbEn { get; set; }

        [MaxLength(30)]
        public string VtGr { get; set; }

        [MaxLength(30)]
        public string VtPl { get; set; }

        [MaxLength(30)]
        public string VtRu { get; set; }

        [Required]
        [MaxLength(30)]
        [ForeignKey("VerbTr")]
        public string VtTr { get; set; }
        public VerbTr VerbTr { get; set; }
    }
}
