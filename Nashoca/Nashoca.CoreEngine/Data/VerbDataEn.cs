using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Data
{
    public static class VerbDataEn
    {
        public static readonly string[] persons = ["I", "you", "he", "she", "it", "we", "you", "they"];
        public static readonly string[] cPersons = ["am", "are", "is", "is", "is", "are", "are", "are"];
        public static readonly string[] csPersons = ["I'm", "You're", "He's", "He's", "He's", "We're", "You're", "They're"];
        public static readonly string[] snPersons = ["do", "do", "does", "does", "does", "do", "do", "do"];
        public static readonly string[] snsPersons = ["don't", "don't", "doesn't", "doesn't", "doesn't", "don't", "don't"];
        public static readonly string futureModal = "will";
        public static readonly string pastModal = "did";
    }
}
