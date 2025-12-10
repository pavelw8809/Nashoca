using Nashoca.CoreEngine.Domain.Interfaces;
using Nashoca.CoreEngine.Infrastructure.Data.Verbs;
using Nashoca.CoreEngine.Infrastructure.Models.Verbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.FormAvailability
{
    public class VerbAvailability : IFormAvailability
    {
        public List<int> GetAvailableForms(string ruleInput)
        {
            List<int> availableForms = VerbCatalogIndex.formList;

            string[] verbRules = ruleInput.Split('/');

            string getByPersonality = verbRules[0];
            string getMainRule = verbRules[1];

            switch (getByPersonality)
            {
                case "p":
                    availableForms = availableForms.Where(x => x % 5 != 0 || x == 0).ToList();
                    break;
                case "n":
                    availableForms = availableForms.Where(x => x % 5 == 0 || x == 0).ToList();
                    break;
                default:
                    break;
            }

            foreach (string rule in verbRules[2..])
            {
                bool isInt = int.TryParse(rule, out int ruleInt);

                if (isInt) 
                {
                    if (getMainRule == "!")
                    {
                        availableForms = availableForms.Where(x => (x / 100) % 10 != ruleInt || x == 0).ToList();
                    }
                    else
                    {
                        availableForms = availableForms.Where(x => (x / 100) % 10 == ruleInt || x == 0).ToList();
                    }
                }
            }

            return availableForms;
        }
    }
}
