using Nashoca.CoreEngine.Infrastructure.Common.Utils;
using Nashoca.CoreEngine.Infrastructure.Data.Nouns;
using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;

namespace Nashoca.CoreEngine.Domain.ConstructionBuilders.Nouns.Turkish
{
    public abstract class NounConstructionBase
    {
        protected NounInputObjTrEn Input { get; set; }
        protected HarmonyInfoObj HarmonyInfo { get; set; }

        protected NounConstructionBase(NounInputObjTrEn input)
        {
            Input = input;
            HarmonyInfo = VowelHelper.GetHarmonyInfo(input.TrMainF);
        }

        public virtual string GetName() => Input.TrName;

        public virtual string GetFormCode(int FormNo)
        {
            string codeNo = FormNo.ToString().PadLeft(5, '0');
            return $"{Input.TrSymbol}-{Input.TransId}-{codeNo}";
        }

        public virtual SuffixResult GetRootSuffix(NounPropsObj nounProps)
        {
            SuffixResult output = new()
            {
                Type = NounAnnotations.RootSuffix,
                TypeSymbol = NounAnnotations.RootSymbol,
                Value = string.IsNullOrWhiteSpace(Input.TrPrefP) ? Input.TrMainF : $"{Input.TrPrefP} {Input.TrMainF}",
                Description = NounAnnotations.RootSuffix,
            };

            if (Input.TrIsConsonantChanged)
            {
                char? changeLetter = ConsonantHelper.GetVoicedConsonant(Input.TrMainF[^1]);

                if (changeLetter != null)
                {
                    output.Value = ConsonantHelper.ReplaceLastLetter(Input.TrMainF, changeLetter);
                    output.Description = string.Format(NounAnnotations.RootInfoChg, Input.TrMainF[^1], changeLetter);
                }
            }

            if (!string.IsNullOrWhiteSpace(Input.TrDefS))
            {
                if (Input.TrDefS.Length > 1)
                {
                    if (ConsonantHelper.IsStringEndingReverted(Input.TrMainF, Input.TrDefS))
                    {
                        switch(nounProps.Case)
                        {
                            case 1:
                                output.Value = ConsonantHelper.ReplaceStringEnding(Input.TrMainF, Input.TrDefS);
                                break;
                            case 2:
                                string accForm = ConsonantHelper.ReplaceStringEnding(Input.TrMainF, Input.TrDefS);
                                output.Value = ConsonantHelper.ReplaceLastLetter(accForm, VowelHelper.GetAEVowelHarmony(accForm));
                                break;
                            case 5:
                                output.Value = ConsonantHelper.ReplaceStringEnding(Input.TrMainF, Input.TrDefS);
                                break;
                            default:
                                output.Value = $"{Input.TrMainF}";
                                break;
                        }
                    }
                }
            }
            else
            {
                // default
            }




                // if (nounProps.Case == 2) -> nehir, nehre
                //if (nounProps.Case == 1 || nounProps.Case == )

                return output;
        }
    }
}
