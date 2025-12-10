using Nashoca.CoreEngine.Infrastructure.Common.Utils;

namespace Nashoca.Tests.CoreEngine
{
    public class StringModifiers
    {
        public static IEnumerable<object[]> GetTestExamples()
        {
            List<(string Word, int Position, string Expected)> examples = new()
            {
                ("şehir", 2, "şehr"),
                ("nehir", 2, "nehr"),
                ("abcd", 1, "abc"),
                ("abcd", 3, "acd")
            };

            foreach (var example in examples)
            {
                yield return new object[] { example };
            }
        }

        [Theory]
        [MemberData(nameof(GetTestExamples))]
        public void StringHelper_CheckIfResultIsCorrect((string Word, int Position, string Expected) example)
        {
            string result = StringHelper.RemoveLetterFromEnd(example.Word, example.Position);

            Assert.Equal(example.Expected, result);
        }
    }
}
