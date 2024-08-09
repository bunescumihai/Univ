namespace AppCore.Contracts;

public interface IPrototype<TObject>
{
    public TObject Clone();
}