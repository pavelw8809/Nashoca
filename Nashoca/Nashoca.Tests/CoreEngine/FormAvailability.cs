using Nashoca.CoreEngine.Domain.FormAvailability;
using Nashoca.Tests.Model;

namespace Nashoca.Tests.CoreEngine
{
    public class FormAvailability
    {
        public static IEnumerable<object[]> GetRuleList()
        {
            IEnumerable<AvailabiltyCheckObj> rules = [
                new AvailabiltyCheckObj() { 
                    Rule = "p/+/2", 
                    ExpectedList = [
                        0,
                        201, 202, 203, 204, 206, 207, 208,
                        211, 212, 213, 214, 216, 217, 218,
                        221, 222, 223, 224, 226, 227, 228,
                        231, 232, 233, 234, 236, 237, 238,
                        242, 248, 252, 258, 262, 268, 272, 278
                    ] 
                },
                new AvailabiltyCheckObj() {
                    Rule = "n/!/2/4",
                    ExpectedList = [
                        0,
                        105, 115, 125, 135, 
                        305, 315, 325, 335, 
                        505, 515, 525, 535, 
                        2105, 2115, 2125, 2135
                    ]
                }
            ];

            foreach (var rule in rules)
            {
                yield return new object[] { rule };
            }
        }

        [Theory]
        [MemberData(nameof(GetRuleList))]
        public void FormAvailability_CheckAvaibilityList(AvailabiltyCheckObj availabililityCheckObj)
        {
            VerbAvailability verbAvailability = new();
            List<int> generatedForms = verbAvailability.GetAvailableForms(availabililityCheckObj.Rule);

            Assert.Equal(availabililityCheckObj.ExpectedList.OrderBy(x => x), generatedForms.OrderBy(x => x));
        }
    };
}
