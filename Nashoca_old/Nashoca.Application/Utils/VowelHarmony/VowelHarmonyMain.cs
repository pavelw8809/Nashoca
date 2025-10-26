using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Utils.VowelHarmony
{
    public class VowelHarmonyMain : IVowelHarmony
    {
        public string GetVowel(string content)
        {
            string lastVowel = Utils.GetLastVowel(content);

            return lastVowel switch
            {
                var l when l == "a" || l == "ı" => "ı",
                var l when l == "e" || l == "i" => "i",
                var l when l == "o" || l == "u" => "u",
                var l when l == "ö" || l == "ü" => "ü",
                _ => null
            };  
        }
    }
}
