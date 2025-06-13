using MediatR;
using Nashoca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.Application.Queries
{
    public class GetAllVerbsQuery : IRequest<List<VerbDto>>
    {
    }
}
