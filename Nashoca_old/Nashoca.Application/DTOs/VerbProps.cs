using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.DTOs
{
    public class VerbProps
    {
        public bool IsNegative { get; set; }
        public bool IsQuestion { get; set; }
        public bool IsPlural { get; set; }
        public int Person { get; set; }
    }
}
