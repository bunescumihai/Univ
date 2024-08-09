namespace AppCore.Services.NotificationSender;

public class NotifSender : Sender
{
    private Sender _sender;
    
    public NotifSender(Sender sender)
    {
        _sender = sender;
    }

    public override void Send()
    {
        _sender.Send();
    }
}