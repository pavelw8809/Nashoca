using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Models;

namespace Nashoca.CoreEngine.Generators.Turkish
{
    public interface IVerbConstruction
    {
        VerbPropsObj GetVerbProps();
        string GetFormCode();
        SuffixResult GetRootSuffix();
        SuffixResult GetNegationSuffix();
        SuffixResult GetConsonantBuffer0();
        SuffixResult GetTense0Suffix();
        SuffixResult GetTense1PreSuffix();
        SuffixResult GetPluralSuffix();
        SuffixResult GetQuestionSuffix();
        SuffixResult GetConsonantBuffer1(string outputForm, string personSuffix);
        SuffixResult GetTense1PostSuffix();
        SuffixResult GetPersonSuffix();
        SuffixResult GetQuestionSuffixPost();
    }
}
