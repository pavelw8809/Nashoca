using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Models
{
    public class InputObjTrEn
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
        public int TransId { get; set; }
    }
}
