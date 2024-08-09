namespace AppCore.Services.Strategy;

public class MicbPayment : IPaymentMethod
{
    private string _idnp;
    private int _sum;
    
    public MicbPayment(string idnp, int sum)
    {
        _idnp = idnp;
        _sum = sum;
    }
    public void Pay()
    {
        Console.WriteLine("Conexiune la Micb...");
        Console.WriteLine("Achitarea a fost efectuata");
    }
}