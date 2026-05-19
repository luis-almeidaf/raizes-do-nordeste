namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public abstract class RaizedDoNordesteException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors(); 
}