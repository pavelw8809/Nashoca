using Nashoca.CoreEngine.Infrastructure.Models.Main;
using Nashoca.CoreEngine.Infrastructure.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Domain.Interfaces
{
    public interface INounRoot<T>
    {
        SuffixResult GetRoot(T input, FullInfoObj info, NounPropsObj props);
    }
}
