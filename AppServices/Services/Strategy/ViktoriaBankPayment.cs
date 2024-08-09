namespace AppCore.Services.Strategy;

public class ViktoriaBankPayment : IPaymentMethod
{
    private string _idnp;
    private int _sum;
    
    public ViktoriaBankPayment(string idnp, int sum)
    {
        _idnp = idnp;
        _sum = sum;
    }
    public void Pay()
    {
        Console.WriteLine("Conexiune la ViktoriaBank...");
        Console.WriteLine("Achitarea a fost efectuata");
    }
}