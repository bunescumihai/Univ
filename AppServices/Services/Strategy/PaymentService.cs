namespace AppCore.Services.Strategy;

public class PaymentService
{

    public IPaymentMethod PaymentMethod;

    public PaymentService(IPaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void Pay()
    {
        PaymentMethod.Pay();
        Console.WriteLine("BD: Statut schimbat in 'achitat'");
    }
}