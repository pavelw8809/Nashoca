using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Domain.Entities
{
    public class VerbTr
    {
        public int Id { get; set; } 
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string PrefP { get; set; }
        public string MainF { get; set; }
        public string MinF { get; set; }
        public string AoristS { get; set; }
        public string PassS { get; set; }
        public string Rules { get; set; }
    }
}
