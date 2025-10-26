using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Models
{
    public class VerbPropsObj
    {
        public int ConstructCode { get; set; }
        public bool IsNegation { get; set; }
        public bool IsQuestion { get; set; }
        public int Person { get; set; }
        public int PersonNumber { get; set; }
        public bool IsPlural { get; set; }
        public string PersonType { get; set; }
    }
}
