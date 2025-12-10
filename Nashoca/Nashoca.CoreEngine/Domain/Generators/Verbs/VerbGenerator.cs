using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.Turkish;
using Nashoca.CoreEngine.Domain.ConstructionBuilders.Verbs.English;
using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;
using Nashoca.CoreEngine.Domain.FormAvailability;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;

namespace Nashoca.CoreEngine.Domain.Generators.Verbs
{
    public class VerbGenerator : IFormGenerator<VerbInputObjTrEn, VerbOutputObjTrEn>
    {
        public ICollection<VerbOutputObjTrEn> GenerateMany(VerbInputObjTrEn inputObj, List<int>formList)
        {
            IFormAvailability formAvailability = new VerbAvailability();
            ICollection<VerbOutputObjTrEn> outputList = [];

            List<int> availableForms = formAvailability.GetAvailableForms(inputObj.TrRules);
            IEnumerable<int> filteredForms = formList.Intersect(availableForms);

            if (filteredForms.Any())
            {
                var fcList = VerbCatalogIndex.verbGroups.Select(g => new VerbInputObjTrEnCollection()
                {
                    GroupId = g.GroupId,
                    GroupItems = filteredForms.Where(x => x >= g.Min && x <= g.Max)
                });

                /*
                IEnumerable<int> f0List = filteredForms.Where(x => x < 100);
                IEnumerable<int> f1List = filteredForms.Where(x => x >= 100 && x <= 199);
                IEnumerable<int> f2List = filteredForms.Where(x => x >= 200 && x <= 299);
                IEnumerable<int> f3List = filteredForms.Where(x => x >= 300 && x <= 399);
                IEnumerable<int> f5List = filteredForms.Where(x => x >= 500 && x <= 599);
                IEnumerable<int> f4List = filteredForms.Where(x => x >= 400 && x <= 499);
                IEnumerable<int> f21List = filteredForms.Where(x => x >= 2100 && x <= 2199);

                IEnumerable<VerbInputObjTrEnCollection> fcList = [
                    new VerbInputObjTrEnCollection() {
                        GroupId = 0,
                        GroupItems = f0List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 1,
                        GroupItems = f1List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 2,
                        GroupItems = f2List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 3,
                        GroupItems = f3List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 4,
                        GroupItems = f4List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 5,
                        GroupItems = f5List
                    },
                    new VerbInputObjTrEnCollection() {
                        GroupId = 21,
                        GroupItems = f21List
                    }
                ];
                */
                
                foreach (VerbInputObjTrEnCollection listObj in fcList)
                {
                    if (listObj.GroupItems.Any())
                    {
                        (VerbConstructionBase, VerbConstructionEnBase) verbConstruction = GetBaseObjects(inputObj, listObj.GroupId);
                        
                        foreach (int formId in listObj.GroupItems)
                        {
                            VerbPropsObj verbPropsObj = VerbPropsHandler.GetVerbProps(formId);
                            outputList.Add(VerbItemGenerator.GenerateVerbItem(verbConstruction.Item1, verbConstruction.Item2, verbPropsObj, formId));
                        }
                    }
                }
            }

            return outputList;
        }

        public VerbOutputObjTrEn GenerateOne(VerbInputObjTrEn inputObj, int formNo)
        {
            if (inputObj == null)
            {
                int constructId = formNo / 100;
                (VerbConstructionBase, VerbConstructionEnBase) verbConstruction = GetBaseObjects(inputObj, constructId);

                VerbPropsObj verbPropsObj = VerbPropsHandler.GetVerbProps(formNo);
                return VerbItemGenerator.GenerateVerbItem(verbConstruction.Item1, verbConstruction.Item2, verbPropsObj, formNo);
            }

            return null;
        }

        private (VerbConstructionBase, VerbConstructionEnBase) GetBaseObjects(VerbInputObjTrEn inputObj, int ConstructId)
        {
            return ConstructId switch
            {
                1 => (new PresentContinuous(inputObj), new PresentContinuousEn(inputObj)),
                2 => (new Aorist(inputObj), new AoristEn(inputObj)),
                3 => (new PastSimple(inputObj), new PastSimpleEn(inputObj)),
                4 => (new PastSimpleNw(inputObj), new PastSimpleNwEn(inputObj)),
                5 => (new FutureSimple(inputObj), new FutureSimpleEn(inputObj)),
                21 => (new AbilityAorist(inputObj), new AbilityAoristEn(inputObj)),
                _ => (null, null)
            };
        }
        
        /*
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

                    VerbPropsObj verbProps = VerbPropsHandler.GetVerbProps(form.FormNo);

                    string formCode = verbConstructionTr.GetFormCode(form.FormNo);

                    StringBuilder formOutput = new StringBuilder();
                    StringBuilder engOutput = new StringBuilder();
                    ICollection<SuffixResult> suffixList = new List<SuffixResult>();

                    SuffixResult root = verbConstructionTr.GetRootSuffix(verbProps);
                    formOutput.Append(root.Value);
                    suffixList.Add(root);

                    SuffixResult abilitypre = verbConstructionTr.GetAbilityPreSuffix(verbProps);
                    if (abilitypre != null)
                    {
                        formOutput.Append(abilitypre.Value);
                        suffixList.Add(abilitypre);
                    }

                    SuffixResult ability = verbConstructionTr.GetAbilitySuffix(verbProps);
                    if (ability != null)
                    {
                        formOutput.Append(ability.Value);
                        suffixList.Add(ability);
                    }

                    SuffixResult negation = verbConstructionTr.GetNegationSuffix(verbProps);
                    if (negation != null)
                    {
                        formOutput.Append(negation.Value);
                        suffixList.Add(negation);
                    }

                    SuffixResult tense0pre = verbConstructionTr.GetTense0PreSuffix(verbProps);
                    if (tense0pre != null)
                    {
                        formOutput.Append(tense0pre.Value);
                        suffixList.Add(tense0pre);
                    }

                    SuffixResult tense0 = verbConstructionTr.GetTense0Suffix(verbProps);
                    formOutput.Append(tense0.Value);
                    suffixList.Add(tense0);

                    SuffixResult plural = verbConstructionTr.GetPluralSuffix(verbProps);
                    if (plural != null)
                    {
                        formOutput.Append(plural.Value);
                        suffixList.Add(plural);
                    }

                    SuffixResult question = verbConstructionTr.GetQuestionSuffix(verbProps);
                    if (question != null)
                    {
                        formOutput.Append($" {question.Value}");
                        suffixList.Add(question);
                    }

                    SuffixResult person = verbConstructionTr.GetPersonSuffix(verbProps);
                    
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

                    SuffixResult postQuestion = verbConstructionTr.GetQuestionPostSuffix(verbProps);
                    if (postQuestion != null)
                    {
                        formOutput.Append($" {postQuestion.Value}");
                        suffixList.Add(postQuestion);
                    }

                    // ENGLISH FORM

                    string enModalQuestion = verbConstructionEn.GetModalQuestion(verbProps);
                    if (enModalQuestion != null)
                    {
                        engOutput.Append($"{enModalQuestion} ");
                    }

                    string enPerson = verbConstructionEn.GetPerson(verbProps);
                    if (enPerson != null)
                    {
                        engOutput.Append($"{enPerson}");
                    }

                    string enModal = verbConstructionEn.GetModal(verbProps);

                    string enNegation = verbConstructionEn.GetNegation(verbProps);

                    string enVerbForm = verbConstructionEn.GetVerbForm(verbProps);

                    EnTranslationInfo enTranslationInfo = GetTranslationInfo(form, verbConstructionEn, verbProps);

                    // present

                    
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

        private static EnTranslationInfo GetTranslationInfo(InputObjTrEn formObj, VerbConstructionEnBase verbConstructionEn, VerbPropsObj verbPropsObj)
        {
            StringBuilder enOutput = new();

            string enModalQuestion = verbConstructionEn.GetModalQuestion(verbPropsObj);

            if (enModalQuestion != null)
            {
                enOutput.Append($"{enModalQuestion} ");
            }

            string enPerson = verbConstructionEn.GetPerson(verbPropsObj);
            if (enPerson != null)
            {
                enOutput.Append($"{enPerson} ");
            }

            string enModal = verbConstructionEn.GetModal(verbPropsObj);
            if (enModal != null)
            {
                enOutput.Append($"{enModal} ");
            }

            string enNegation = verbConstructionEn.GetNegation(verbPropsObj);
            if (enNegation != null)
            {
                enOutput.Append($"{enNegation} ");
            }

            string enVerbForm = verbConstructionEn.GetVerbForm(verbPropsObj);
            enOutput.Append(enVerbForm);

            return new EnTranslationInfo()
            {
                EnMainForm = formObj.EnMainF,
                EnTranslation = enOutput.ToString(),
                EnDescription = verbConstructionEn.ConstructionDescEn,
                EnConstructionName = verbConstructionEn.ConstructionNameEn,
            };
        }
        */
    }
}
