using MediatR;
using Nashoca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Commands
{
    public class CreateVerbCommand : IRequest<Unit>
    {
        public VerbDto Verb { get; set; }
    }
}
