using System.Text;
using Nashoca.CoreEngine.Generators.English;
using Nashoca.CoreEngine.Generators.Turkish;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Models.Verbs;

public class VerbItemGenerator
{
    public OutputObjTrEn GenerateVerbItem(VerbConstructionBase inputTr, VerbConstructionEnBase inputEn, VerbPropsObj verbPropsObj)
    {
        string formCode = inputTr.GetFormCode();

        StringBuilder formOutput = new();
        StringBuilder engOutput = new();
        List<SuffixResult> suffixList = new List<SuffixResult>();

        SuffixResult root = inputTr.GetRootSuffix();
        SuffixResult abilitypre = inputTr.GetAbilityPreSuffix();
        SuffixResult ability = inputTr.GetAbilitySuffix();
        SuffixResult negation = inputTr.GetNegationSuffix();
        SuffixResult tense0pre = inputTr.GetTense0PreSuffix();
        SuffixResult tense0 = inputTr.GetTense0Suffix();
        SuffixResult tense1pre = inputTr.GetTense1Suffix();
        SuffixResult tense1 = inputTr.GetTense1Suffix();
        SuffixResult plural = inputTr.GetPluralSuffix();
        SuffixResult question = inputTr.GetQuestionSuffix();
        SuffixResult tense1post = inputTr.GetTense1PostSuffix();
        SuffixResult person = inputTr.GetPersonSuffix();
        SuffixResult questionpost = inputTr.GetQuestionSuffixPost();

        IEnumerable<SuffixResult> suffixResults = [root, abilitypre, ability, negation, tense0pre, tense0, tense1pre, tense1, plural, question, tense1post, person, questionpost];

        foreach (SuffixResult suffixResult in suffixResults)
        {
            if (!string.IsNullOrWhiteSpace(suffixResult.Value))
            {

                if (suffixResult.TypeSymbol == "question")
                {
                    formOutput.Append($" {questionpost.Value}");
                    suffixList.Add(questionpost);

                    SuffixResult consbuf = inputTr.GetConsonantBuffer1(formOutput.ToString(), person.Value);
                    if (!string.IsNullOrWhiteSpace(consbuf.Value))
                    {
                        formOutput.Append($" {consbuf.Value}");
                        suffixList.Add(consbuf);
                    }
                }
                else if (suffixResult.TypeSymbol == "questionpost")
                {
                    formOutput.Append($" {questionpost.Value}");
                    suffixList.Add(questionpost);
                }
                else
                {
                    formOutput.Append(root.Value);
                    suffixList.Add(suffixResult);
                }
            }
        }

        // English

        IEnumerable<string> enParts = [
            inputEn.GetModalQuestion(),
            inputEn.GetPerson(),
            inputEn.GetModal(),
            inputEn.GetNegation(),
            inputEn.GetVerbForm()
        ];

        foreach (string enPart in enParts)
        {
            if (!string.IsNullOrWhiteSpace(enPart))
            {
                engOutput.Append($"{enPart} ");
            }
        };

        return new OutputObjTrEn()
        {
            Type = "V",
            FormCode = formCode,
            Name = inputTr.GetName(),
            FormName = formOutput.ToString(),
            IsPlural = verbPropsObj.IsPlural,
            Person = verbPropsObj.PersonNumber,
            ConstructionNameTr = inputTr.ConstructionNameTr,
            SuffixList = suffixList,
            EnTranslation = new EnTranslationInfo()
            {
                EnMainForm = inputEn.GetName(),
                EnTranslation = engOutput.ToString().Trim(),
                EnDescription = inputEn.ConstructionDescEn,
                EnConstructionName = inputEn.ConstructionNameEn
            }
        };
    }
}