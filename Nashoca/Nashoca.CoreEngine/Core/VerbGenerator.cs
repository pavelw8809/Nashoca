using Nashoca.CoreEngine.Generators.English;
using Nashoca.CoreEngine.Generators.Turkish;
using Nashoca.CoreEngine.Models.Verbs;
using Nashoca.CoreEngine.Models;
using System.Text;

namespace Nashoca.CoreEngine.Core
{
    public class VerbGenerator : IFormGenerator<InputObjTrEn, OutputObjTrEn>
    {
        public ICollection<OutputObjTrEn> GenerateMany(ICollection<InputObjTrEn> formList)
        {
            ICollection<OutputObjTrEn> outputList = new List<OutputObjTrEn>();

            if (formList.Any())
            {
                IEnumerable<InputObjTrEn> f1List = formList.Where(x => x.FormNo >= 100 && x.FormNo <= 199);
                IEnumerable<InputObjTrEn> f2List = formList.Where(x => x.FormNo >= 200 && x.FormNo <= 299);
                IEnumerable<InputObjTrEn> f3List = formList.Where(x => x.FormNo >= 300 && x.FormNo <= 399);
                IEnumerable<InputObjTrEn> f4List = formList.Where(x => x.FormNo >= 400 && x.FormNo <= 499);
                IEnumerable<InputObjTrEn> f5List = formList.Where(x => x.FormNo >= 500 && x.FormNo <= 599);
                IEnumerable<InputObjTrEn> f21List = formList.Where(x => x.FormNo >= 2100 && x.FormNo <= 2199);

                IEnumerable<InputObjTrEnCollection> fcList = [
                    new InputObjTrEnCollection() {
                        GroupId = 1,
                        GroupItems = f1List
                    },
                    new InputObjTrEnCollection() {
                        GroupId = 2,
                        GroupItems = f2List
                    },
                    new InputObjTrEnCollection() {
                        GroupId = 3,
                        GroupItems = f3List
                    },
                    new InputObjTrEnCollection() {
                        GroupId = 4,
                        GroupItems = f4List
                    },
                    new InputObjTrEnCollection() {
                        GroupId = 5,
                        GroupItems = f5List
                    },
                    new InputObjTrEnCollection() {
                        GroupId = 21,
                        GroupItems = f21List
                    }
                ];
                
                foreach (InputObjTrEnCollection listObj in fcList)
                {
                    if (listObj.GroupItems.Any())
                    {
                        InputObjTrEn firstInputObj = listObj.GroupItems.First();
                        (VerbConstructionBase verbConstructionTr, VerbConstructionEnBase verbConstructionEn) = listObj.GroupId switch
                        {
                            1 => (new PresentContinuous(firstInputObj), new PresentContinuousEn(firstInputObj)),
                            2 => (new Aorist(firstInputObj), new AoristEn(firstInputObj)),
                            3 => (new PastSimple(firstInputObj), new PastSimpleEn(firstInputObj)),
                            4 => (new PastSimpleNw(firstInputObj), new PastSimpleNwEn(firstInputObj)),
                            5 => (new FutureSimple(firstInputObj), new FutureSimpleEn(firstInputObj)),
                            21 => (new AbilityAorist(firstInputObj), new AbilityAoristEn(firstInputObj)),
                            _ => ((VerbConstructionBase)null, (VerbConstructionEnBase)null)
                        };

                        VerbPropsObj verbPropsObj = verbConstructionTr.GetVerbProps();
                        
                        foreach (InputObjTrEn input in listObj.GroupItems)
                        {
                            Outp
                        }
                    }
                }
            }
        }
        
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
                        > 2100 => (new AbilityAorist(form), new AbilityAoristEn(form)), 
                        > 500 => (new FutureSimple(form), new FutureSimpleEn(form)),
                        > 400 => (new PastSimpleNw(form), new PastSimpleNwEn(form)),
                        > 300 => (new PastSimple(form), new PastSimpleEn(form)),
                        > 200 => (new Aorist(form), new AoristEn(form)),
                        > 100 => (new PresentContinuous(form), new PresentContinuousEn(form)),
                        _ => ((VerbConstructionBase)null, (VerbConstructionEnBase)null)
                    };

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

                    SuffixResult tense0pre = verbConstructionTr.GetTense0PreSuffix();
                    if (tense0pre != null)
                    {
                        formOutput.Append(tense0pre.Value);
                        suffixList.Add(tense0pre);
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
