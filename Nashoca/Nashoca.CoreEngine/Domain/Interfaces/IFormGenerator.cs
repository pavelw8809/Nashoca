namespace Nashoca.CoreEngine.Domain.Interfaces
{
    public interface IFormGenerator<T, U>
    {
        ICollection<U> GenerateMany(T inputObj, List<int> formList);
        U GenerateOne(T inputObj, int FormNo);
    }
}
