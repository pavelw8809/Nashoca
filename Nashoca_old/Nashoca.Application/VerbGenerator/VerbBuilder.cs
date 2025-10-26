using Nashoca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Logic
{
    public class VerbBuilder
    {
        public VerbObj GenerateForm(VerbDto VetbDto, int FormId)
        {
            string constructCode = GetVerbConstructName(FormId);

            string getRoot = GetVerbRoot(VetbDto, constructCode);
        }

        private string GetVerbConstructName(int FormId)
        {
            switch (FormId)
            {
                case int id when id > 100 && id < 200:
                    return "prCn";
                case int id when id > 200 && id < 300:
                    return "ao";
                default:
                    return "main";
            }
        }
    }
}
