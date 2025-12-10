using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Domain.Entities
{
    public class NounTr
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string PrefP { get; set; }
        public string MainF { get; set; }
        public string DefS { get; set; }
        public bool IsVd { get; set; }
        public bool IsCc { get; set; }
        public bool IsB { get; set; }
        public bool IsH { get; set; }
        public bool IsP { get; set; }
        public bool IsPl { get; set; }
        public bool IsC { get; set; }
        public bool IsCP { get; set; }
        public bool IsBP { get; set; }
        public bool IsHP { get; set; }
        public bool IsDative { get; set; }
    }
}
