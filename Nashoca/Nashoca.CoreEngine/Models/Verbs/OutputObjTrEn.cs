using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Models.Verbs
{
    public class OutputObjTrEn
    {
        public string Type { get; set; }
        public string FormCode { get; set; }
        public string Name { get; set; }
        public string FormName { get; set; }
        public bool IsPlural { get; set; }
        public int Person { get; set; }
        public string ConstructionNameTr { get; set; }
        public ICollection<SuffixResult> SuffixList { get; set; }
        public EnTranslationInfo EnTranslation { get; set; }
    }
}
