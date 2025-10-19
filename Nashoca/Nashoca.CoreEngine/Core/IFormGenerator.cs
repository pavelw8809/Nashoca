using Nashoca.CoreEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Core
{
    public interface IFormGenerator<T, U>
    {
        ICollection<U> Generate(IEnumerable<T> formList);
    }
}
