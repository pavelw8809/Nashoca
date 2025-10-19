using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Domain.Entities
{
    public class VerbEnMin
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string PrefP { get; set; }
        public string MainF { get; set; }
        public string PostP { get; set; }
        public string ContF { get; set; }
        public string PastF { get; set; }
        public string PPastF { get; set; }
        public string Rules { get; set; }
    }
}
