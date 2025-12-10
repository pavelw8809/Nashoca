using Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English;
using Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;
using System.Text;

namespace Nashoca.CoreEngine.Domain.Generators.Verbs
{
    public static class VerbItemGenerator
    {
        public static VerbOutputObjTrEn GenerateVerbItem(VerbConstructionBase inputTr, VerbConstructionEnBase inputEn, VerbPropsObj verbPropsObj, int FormNo)
        {
            string formCode = inputTr.GetFormCode(FormNo);

            StringBuilder formOutput = new();
            StringBuilder engOutput = new();
            List<SuffixResult> suffixList = new List<SuffixResult>();

            SuffixResult root = inputTr.GetRootSuffix(verbPropsObj);
            SuffixResult abilitypre = inputTr.GetAbilityPreSuffix(verbPropsObj);
            SuffixResult ability = inputTr.GetAbilitySuffix(verbPropsObj);
            SuffixResult negation = inputTr.GetNegationSuffix(verbPropsObj);
            SuffixResult tense0pre = inputTr.GetTense0PreSuffix(verbPropsObj);
            SuffixResult tense0 = inputTr.GetTense0Suffix(verbPropsObj);
            SuffixResult tense1pre = inputTr.GetTense1Suffix(verbPropsObj);
            SuffixResult tense1 = inputTr.GetTense1Suffix(verbPropsObj);
            SuffixResult plural = inputTr.GetPluralSuffix(verbPropsObj);
            SuffixResult question = inputTr.GetQuestionSuffix(verbPropsObj);
            //SuffixResult tense1post = inputTr.GetTense1PostSuffix(  );
            SuffixResult person = inputTr.GetPersonSuffix(verbPropsObj);
            SuffixResult questionpost = inputTr.GetQuestionPostSuffix(verbPropsObj);

            IEnumerable<SuffixResult> suffixResults = [root, abilitypre, ability, negation, tense0pre, tense0, tense1pre, tense1, plural, question, /*tense1post, */person, questionpost];

            foreach (SuffixResult suffixResult in suffixResults)
            {
                if (suffixResult != null && suffixResult.Value != null)
                {
                    if (suffixResult.TypeSymbol == VerbAnnotations.PersonSymbol)
                    {
                        if (!string.IsNullOrWhiteSpace(formOutput.ToString()) && person.Value != null)
                        {
                            SuffixResult consbuf = inputTr.GetConsonantBuffer1(formOutput.ToString(), person.Value);
                            if (consbuf != null && !string.IsNullOrWhiteSpace(consbuf.Value))
                            {
                                formOutput.Append($"{consbuf.Value}");
                                suffixList.Add(consbuf);
                            }
                        }

                        formOutput.Append(suffixResult.Value);
                        suffixList.Add(suffixResult);
                    }
                    else if (suffixResult.TypeSymbol == VerbAnnotations.QuestionSymbol || suffixResult.TypeSymbol == VerbAnnotations.QuestionPostInfo)
                    {
                        formOutput.Append($" {suffixResult.Value}");
                        suffixList.Add(suffixResult);
                    }
                    else
                    {
                        formOutput.Append(suffixResult.Value);
                        suffixList.Add(suffixResult);
                    }
                }
            }

            // English

            IEnumerable<string> enParts = [
                inputEn.GetModalQuestion(verbPropsObj),
                inputEn.GetPerson(verbPropsObj),
                inputEn.GetModal(verbPropsObj),
                inputEn.GetNegation(verbPropsObj),
                inputEn.GetVerbForm(verbPropsObj)
            ];

            foreach (string enPart in enParts)
            {
                if (!string.IsNullOrWhiteSpace(enPart))
                {
                    engOutput.Append($"{enPart} ");
                }
            }
            ;

            return new VerbOutputObjTrEn()
            {
                Type = "V",
                FormCode = formCode,
                Name = inputTr.GetName(),
                FormName = formOutput.ToString(),
                IsPlural = verbPropsObj.IsPlural,
                IsFormal = verbPropsObj.IsFormal,
                Person = verbPropsObj.PersonNumber,
                Case = inputTr.GetCase(),
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
}
