namespace AppCore.Services.NotificationSender;

public class ElseSender : Sender
{
    private string _userName;
    private Sender? _sender ;
    
    public ElseSender(string username, Sender? sender = null)
    {
        _userName = username;
        _sender = sender;
    }
    public override void Send()
    {
        if(_sender is not null)
            _sender.Send();
        
        Console.WriteLine("S-a trimis notificare pe else catre " + _userName);
    }
}