namespace AppCore.Services.NotificationSender;

public class EmailSender : Sender
{
    private string _userEmail;
    private Sender? _sender ;
    
    public EmailSender(string userEmail, Sender? sender = null)
    {
        _userEmail = userEmail;
        _sender = sender;
    }
    
    public override void Send()
    {
        if(_sender is not null)
            _sender.Send();
        
        Console.WriteLine("S-a trimis notificare pe email catre " + _userEmail);
    }
}