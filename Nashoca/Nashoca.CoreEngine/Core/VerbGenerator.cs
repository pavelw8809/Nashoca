using Nashoca.CoreEngine.Generators.English;
using Nashoca.CoreEngine.Generators.Turkish;
using Nashoca.CoreEngine.Models;
using Nashoca.CoreEngine.Utils;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Core
{
    public class VerbGenerator : IFormGenerator<InputObjTrEn, OutputObjTrEn>
    {
        public ICollection<OutputObjTrEn> Generate(IEnumerable<InputObjTrEn> formList)
        {
            ICollection<OutputObjTrEn> outputList = new List<OutputObjTrEn>();

            if (formList.Any())
            {
                foreach (InputObjTrEn form in formList)
                {
                    (VerbConstructionBase verbConstructionTr, VerbConstructionEnBase verbConstructionEn) = 
                    form.FormNo switch 
                    {
                        > 400 => (new PastSimpleNw(form), new PastSimpleNwEn(form)),
                        > 300 => (new PastSimple(form), new PastSimpleEn(form)),
                        > 200 => (new Aorist(form), new AoristEn(form)),
                        > 100 => (new PresentContinuous(form), new PresentContinuousEn(form)),
                        _ => ((VerbConstructionBase)null, (VerbConstructionEnBase)null)
                    };


                    /*
                    VerbConstructionBase verbConstruction = form.FormNo switch
                    {
                        > 300 => new PastSimple(form),
                        > 200 => new Aorist(form),
                        > 100 => new PresentContinuous(form),
                        _ => null
                    };
                    */

                    VerbPropsObj verbProps = verbConstructionTr.GetVerbProps();

                    string formCode = verbConstructionTr.GetFormCode();

                    StringBuilder formOutput = new StringBuilder();
                    StringBuilder engOutput = new StringBuilder();
                    ICollection<SuffixResult> suffixList = new List<SuffixResult>();

                    SuffixResult root = verbConstructionTr.GetRootSuffix();
                    formOutput.Append(root.Value);
                    suffixList.Add(root);

                    SuffixResult abilitypre = verbConstructionTr.GetAbilityPreSuffix();
                    if (abilitypre != null)
                    {
                        formOutput.Append(abilitypre.Value);
                        suffixList.Add(abilitypre);
                    }

                    SuffixResult ability = verbConstructionTr.GetAbilitySuffix();
                    if (ability != null)
                    {
                        formOutput.Append(ability.Value);
                        suffixList.Add(ability);
                    }

                    SuffixResult negation = verbConstructionTr.GetNegationSuffix();
                    if (negation != null)
                    {
                        formOutput.Append(negation.Value);
                        suffixList.Add(negation);
                    }

                    SuffixResult tense0 = verbConstructionTr.GetTense0Suffix();
                    formOutput.Append(tense0.Value);
                    suffixList.Add(tense0);

                    SuffixResult plural = verbConstructionTr.GetPluralSuffix();
                    if (plural != null)
                    {
                        formOutput.Append(plural.Value);
                        suffixList.Add(plural);
                    }

                    SuffixResult question = verbConstructionTr.GetQuestionSuffix();
                    if (question != null)
                    {
                        formOutput.Append($" {question.Value}");
                        suffixList.Add(question);
                    }

                    SuffixResult person = verbConstructionTr.GetPersonSuffix();
                    
                    SuffixResult consBuffer1 = verbConstructionTr.GetConsonantBuffer1(formOutput.ToString(), person?.Value);
                    if (consBuffer1 != null)
                    {
                        formOutput.Append(consBuffer1.Value);
                        suffixList.Add(consBuffer1);
                    }

                    if (person != null)
                    {
                        formOutput.Append(person.Value);
                        suffixList.Add(person);
                    }

                    SuffixResult postQuestion = verbConstructionTr.GetQuestionSuffixPost();
                    if (postQuestion != null)
                    {
                        formOutput.Append($" {postQuestion.Value}");
                        suffixList.Add(postQuestion);
                    }

                    // ENGLISH FORM

                    string enModalQuestion = verbConstructionEn.GetModalQuestion();
                    if (enModalQuestion != null)
                    {
                        engOutput.Append($"{enModalQuestion} ");
                    }

                    string enPerson = verbConstructionEn.GetPerson();
                    if (enPerson != null)
                    {
                        engOutput.Append($"{enPerson}");
                    }

                    string enModal = verbConstructionEn.GetModal();

                    string enNegation = verbConstructionEn.GetNegation();

                    string enVerbForm = verbConstructionEn.GetVerbForm();

                    EnTranslationInfo enTranslationInfo = GetTranslationInfo(form, verbConstructionEn);

                    // present

                    /*
                        {
                            type: "V"
                            formCode: "ANLA-4-0102",
                            name: "Anlamak",
                            formName: "Anliyorsun",
                            isPlural: false,
                            person: 2
                            constructNameTr: "simdiki zaman"
                            suffixList: []
                            translationInfoEn: {
                                enTranslation: You understand
                                enConstructName: Present Continuous
                                enDesctiprion: (at this moment)
                            }
                        }
                    */

                    outputList.Add(new OutputObjTrEn()
                    {
                        Type = "V",
                        FormCode = formCode,
                        Name = form.TrName,
                        FormName = formOutput.ToString(),
                        IsPlural = verbProps.IsPlural,
                        Person = verbProps.PersonNumber,
                        ConstructionNameTr = verbConstructionTr.ConstructionNameTr,
                        SuffixList = suffixList,
                        EnTranslation = enTranslationInfo
                    });
                }
            }

            return outputList;
        }

        private static EnTranslationInfo GetTranslationInfo(InputObjTrEn formObj, VerbConstructionEnBase verbConstructionEn)
        {
            StringBuilder enOutput = new();

            string enModalQuestion = verbConstructionEn.GetModalQuestion();

            if (enModalQuestion != null)
            {
                enOutput.Append($"{enModalQuestion} ");
            }

            string enPerson = verbConstructionEn.GetPerson();
            if (enPerson != null)
            {
                enOutput.Append($"{enPerson} ");
            }

            string enModal = verbConstructionEn.GetModal();
            if (enModal != null)
            {
                enOutput.Append($"{enModal} ");
            }

            string enNegation = verbConstructionEn.GetNegation();
            if (enNegation != null)
            {
                enOutput.Append($"{enNegation} ");
            }

            string enVerbForm = verbConstructionEn.GetVerbForm();
            enOutput.Append(enVerbForm);

            return new EnTranslationInfo()
            {
                EnMainForm = formObj.EnMainF,
                EnTranslation = enOutput.ToString(),
                EnDescription = verbConstructionEn.ConstructionDescEn,
                EnConstructionName = verbConstructionEn.ConstructionNameEn,
            };
        }
    }
}
