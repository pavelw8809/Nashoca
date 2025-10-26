using Nashoca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Services
{
    public class VerbGenerationService
    {
        public List<VerbObj> GenerateForms(List<VerbDto> VerbDto, List<int> FormList) 
        {
            List<VerbObj> output = new();

            if (FormList.Any())
            {
                foreach (var form in FormList)
                {

                }
            }

            return output;
        }
    }
}
