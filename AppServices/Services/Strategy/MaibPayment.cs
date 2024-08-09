namespace AppCore.Services.Strategy;

public class MaibPayment : IPaymentMethod
{
    private string _idnp;
    private int _sum;
    
    public MaibPayment(string idnp, int sum)
    {
        _idnp = idnp;
        _sum = sum;
    }
    public void Pay()
    {
        Console.WriteLine("Conexiune la Maib...");
        Console.WriteLine("Achitarea a fost efectuata");
    }
}