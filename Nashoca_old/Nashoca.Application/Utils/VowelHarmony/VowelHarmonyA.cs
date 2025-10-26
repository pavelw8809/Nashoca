using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Utils.VowelHarmony
{
    public class VowelHarmonyA : IVowelHarmony
    {
        public string GetVowel(string content)
        {
            string lastVowel = Utils.GetLastVowel(content);

            return lastVowel switch
            {
                var l when l == "a" || l == "ı" || l == "o" || l == "u" => "a",
                var l when l == "e" || l == "i" || l == "ö" || l == "ü" => "e",
                _ => null
            };
        }
    }
}
