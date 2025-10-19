using Nashoca.CoreEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
