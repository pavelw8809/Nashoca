using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Data.Verbs
{
    public static class VerbDataTr
    {
        public static readonly string[] persons = ["ben", "sen", "o", "o", "o", "biz", "siz", "onlar"];
        public static readonly string[] cPersons = ["{0}m", "s{0}n", "", "", "", "{0}z", "s{0}n{0}z", "l{1}r"];
        public static readonly string[] cnPersons = ["m", "s{0}n", "", "", "", "{0}z", "s{0}n{0}z", "l{1}r"];
        public static readonly string[] pPersons = ["m", "n", "", "", "", "k", "n{0}z", "l{1}r"];
    }
}
