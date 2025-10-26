using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Utils.VowelHarmony
{
    public class VowelHarmonyFactory
    {
        public static IVowelHarmony Create(string type)
        {
            return type.ToLower() switch
            {
                "main" => new VowelHarmonyMain(),
                "i" => new VowelHarmonyI(),
                "a" => new VowelHarmonyA(),
                _ => throw new NotSupportedException($"VowelHarmony type: {type} is not supported.")
            };
        }
    }
}
