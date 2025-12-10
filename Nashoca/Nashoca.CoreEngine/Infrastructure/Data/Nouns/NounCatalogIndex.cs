using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Data.Nouns
{
    public class NounCatalogIndex
    {
        public static readonly int[] basicSingularForms = [
            0
        ];

        public static readonly int[] basicPluralForms = [
            100
        ];

        public static readonly int[] possesiveSingularForms = [
            10, 20, 30, 40, 60, 70, 80
        ];

        public static readonly int[] possesivePluralForms = [
            110, 120, 130, 140, 160, 170, 180
        ];

        public static readonly int[] predicativeForms = [
            1, 2, 3, 4, 6, 7, 8,
            201, 202, 203, 204, 206, 207, 208,
            301, 302, 303, 304, 306, 307, 308,
            401, 402, 403, 404, 406, 407, 408
        ];

        public static readonly int[] caseLocativeSingularForms = [
            3000, 3010, 3020, 3030, 3040, 3060, 3070, 3080
        ];

        public static readonly int[] caseLocativePluralForms = [
            3100, 3110, 3120, 3130, 3140, 3160, 3170, 3180
        ];

        public static readonly int[] caseOtherSingularForms = [
            1000, 1010, 1020, 1030, 1040, 1060, 1070, 1080,
            2000, 2010, 2020, 2030, 2040, 2060, 2070, 2080,
            4000, 4010, 4020, 4030, 4040, 4060, 4070, 4080,
            5000, 5010, 5020, 5030, 5040, 5060, 5070, 5080,
            6000, 6010, 6020, 6030, 6040, 6060, 6070, 6080
        ];

        public static readonly int[] caseOtherPlularForms = [
            1100, 1110, 1120, 1130, 1140, 1160, 1170, 1180,
            2100, 2110, 2120, 2130, 2140, 2160, 2170, 2180,
            4100, 4110, 4120, 4130, 4140, 4160, 4170, 4180,
            5100, 5110, 5120, 5130, 5140, 5160, 5170, 5180,
            6100, 6110, 6120, 6130, 6140, 6160, 6170, 6180
        ];

        public static readonly int[] varYokSingularCase = [
            8000, 8010, 8020, 8030, 8040, 8060, 8070, 8080,
            9000, 9010, 9020, 9030, 9040, 9060, 9070, 9080,
            8200, 8210, 8220, 8230, 8240, 8260, 8270, 8280,
            9200, 9210, 9220, 9230, 9240, 9260, 9270, 9280,
            8400, 8410, 8420, 8430, 8440, 8460, 8470, 8480,
            9400, 9410, 9420, 9430, 9440, 9460, 9470, 9480,
            8600, 8610, 8620, 8630, 8640, 8660, 8670, 8680,
            9600, 9610, 9620, 9630, 9640, 9660, 9670, 9680
        ];

        public static readonly int[] varYokPluralCase = [
            8100, 8110, 8120, 8130, 8140, 8160, 8170, 8180,
            9100, 9110, 9120, 9130, 9140, 9160, 9170, 9180,
            8300, 8310, 8320, 8330, 8340, 8360, 8370, 8380,
            9300, 9310, 9320, 9330, 9340, 9360, 9370, 9380,
            8500, 8510, 8520, 8530, 8540, 8560, 8570, 8580,
            9500, 9510, 9520, 9530, 9540, 9560, 9570, 9580,
            8700, 8710, 8720, 8730, 8740, 8760, 8770, 8780,
            9700, 9710, 9720, 9730, 9740, 9760, 9770, 9780
        ];
    }
}
