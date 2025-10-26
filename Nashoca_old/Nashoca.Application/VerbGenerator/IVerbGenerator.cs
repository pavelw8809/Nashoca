using Nashoca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.VerbGenerator
{
    public interface IVerbGenerator
    {
        VerbObj GenerateForm(VerbDto verbDto, VerbProps verbProps);
    }
}
