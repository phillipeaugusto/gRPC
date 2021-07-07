namespace DomainInfo.ConvertPASF.Contracts
{
    public interface IConvertGeneric<out T>
    {
        T Convert();
    }
}