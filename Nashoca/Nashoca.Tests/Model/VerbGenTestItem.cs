using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Tests.Model
{
    internal class VerbGenTestItem
    {
        public string TrSymbol { get; set; }
        public string TrName { get; set; }
        public string TrPrefP { get; set; }
        public string TrMainF { get; set; }
        public string TrMinF { get; set; }
        public string TrAoS { get; set; }
        public string TrPassS { get; set; }
        public string TrRules { get; set; }
        public string EnPrefP { get; set; }
        public string EnMainF { get; set; }
        public string EnPostP { get; set; }
        public string EnContF { get; set; }
        public string EnPastF { get; set; }
        public string EnPPastF { get; set; }
        public string EnRules { get; set; }
        public int FormNo { get; set; }
        public int TestVerbNo { get; set; }
        public int TestFormNo { get; set; }
        public string TestFormCode { get; set; }
        public int TestPersonNo { get; set; }
        public bool TestIsNegation { get; set; }
        public bool TestIsPlural { get; set; }
        public bool TestIsQuestion { get; set; }
        public string TestForm { get; set; }
        public string TestSuffixes { get; set; }
        public string TestEng { get; set; }
    }
}
