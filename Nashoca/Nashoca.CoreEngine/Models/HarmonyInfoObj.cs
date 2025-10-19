using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Models
{
    public class HarmonyInfoObj
    {
        public char? BaseHarmony { get; set; }
        public char? AEHarmony { get; set; }
        public char? IHarmony { get; set; }
        public char? LastVowel { get; set; }
        public bool IsLastCharVowel { get; set; }
        public bool IsLastCharVoiceless { get; set; } 
    }
}
