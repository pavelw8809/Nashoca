using Nashoca.Application.DTOs;
using Nashoca.Application.Utils.VowelHarmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.VerbGenerator
{
    public class PresentContinuousGenerator : IVerbGenerator
    {
        VerbObj GenerateForm(VerbDto verbDto, VerbProps verbProps)
        {
            VerbObj verbObj = new();
            List<VerbItem> verbItems = new();

            VerbItem root = GetRoot(verbDto, verbProps);
            VerbItem negation = GetNegation(verbDto, verbProps);

            return verbObj;
        }

        static private VerbItem GetRoot(VerbDto verbDto, VerbProps verbProps)
        {
            return new VerbItem()
            {
                Name = "Verb Root",
                Value = verbProps.IsNegative ? verbDto.VtrMainF : verbDto.VtrMinF
            };
        }

        static private VerbItem GetNegation(VerbDto verbDto, VerbProps verbProps)
        {
            IVowelHarmony vowelHarmony = VowelHarmonyFactory.Create("main");

            if (verbProps.IsNegative) {
                return new VerbItem()
                {
                    Name = "Negation Suffix",
                    Value = verbProps.IsNegative ? $"m{vowelHarmony.GetVowel(verbDto.VenMainF)}" : null
                };
            }
            else
            {
                return null;
            }
        }
    }
}
