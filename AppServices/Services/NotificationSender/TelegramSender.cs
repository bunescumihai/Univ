namespace AppCore.Services.NotificationSender;

public class TelegramSender: Sender
{
    private string _userName;
    private Sender? _sender ;
    
    public TelegramSender(string username, Sender? sender = null)
    {
        _userName = username;
        _sender = sender;
    }
    public override void Send()
    {
        if(_sender is not null)
            _sender.Send();
        
        Console.WriteLine("S-a trimis notificare pe telegram catre " + _userName);
    }
}