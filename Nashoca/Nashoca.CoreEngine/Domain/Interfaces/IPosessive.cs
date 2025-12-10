using Nashoca.CoreEngine.Infrastructure.Models.Main;

namespace Nashoca.CoreEngine.Domain.Interfaces
{
    public interface IPosessive<T, U>
    {
        SuffixResult GetForm();
    }
}
