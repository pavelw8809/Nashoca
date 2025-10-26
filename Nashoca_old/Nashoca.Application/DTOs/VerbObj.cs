using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.DTOs
{
    public class VerbObj
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string VerbName { get; set; }
        public string Root { get; set; }
        public string ConstructName { get; set; }
        public bool IsNegation { get; set; }
        public bool IsQuestion { get; set; }
        public string FormName { get; set; }
        public List<VerbItem> VerbItems { get; set; } = new List<VerbItem>();
        public string Case { get; set; }
        public string TrEng { get; set; }
    }
}
