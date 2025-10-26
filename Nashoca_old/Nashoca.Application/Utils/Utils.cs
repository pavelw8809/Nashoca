using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Utils
{
    public class Utils
    {
        public static string GetLastVowel(string content)
        {
            string vowels = "aeıioöuüAEIİOÖUÜ";

            return content.Reverse().FirstOrDefault(c => vowels.Contains(c)).ToString();
        }
    }
}
