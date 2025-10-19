using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Tests.Model
{
    public class VerbGenObj
    {
        public int VerbNo { get; set; }
        public int FormNo { get; set; }
        public string FormCode { get; set; }
        public int PersonNo { get; set; }
        public bool IsNegation { get; set; }
        public bool IsPlural { get; set; }
        public bool IsQuestion { get; set; }
        public string Form { get; set; }
        public string Suffixes { get; set; }
        public string Eng { get; set; }
    }
}
