namespace Nashoca.CoreEngine.Domain.Interfaces
{
    internal interface IFormItemGenerator<T, U, V, X>
    {
        public X GenerateItem(T inputTr, U inputEn, V propsObj);
    }
}
