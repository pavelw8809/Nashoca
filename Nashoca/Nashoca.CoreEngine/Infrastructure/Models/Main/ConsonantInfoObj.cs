using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Models.Main
{
    public class ConsonantInfoObj
    {
        public char? VoicedEquivalent { get; set; }
        public bool IsStringEndingReverted { get; set; }
        public char? LastLetter { get; set; }
    }
}
