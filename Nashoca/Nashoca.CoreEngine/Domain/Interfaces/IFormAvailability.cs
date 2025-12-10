using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.Interfaces
{
    public interface IFormAvailability
    {
        List<int> GetAvailableForms(string ruleInput);
    }
}
