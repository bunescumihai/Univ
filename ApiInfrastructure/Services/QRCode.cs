namespace Univ.Services;

public class QRCode
{
    private static QRCode? _qrCode;

    public DateTime GeneratedDateTime { get; private set; }
    public string Code { get; private set; } = string.Empty;

    private QRCode()
    {
        GeneratedDateTime = DateTime.Now;
        GenerateQRCode();
    }
    
    public static QRCode GetInstance()
    {
        if (_qrCode is null)
            _qrCode = new QRCode();

        DateTime timeNow = DateTime.Now;
        
        if((timeNow - _qrCode.GeneratedDateTime).Seconds > 7)
            _qrCode.GenerateQRCode();
        
        return _qrCode;
    }

    public string GetQrCode()
    {
        DateTime timeNow = DateTime.Now;
        
        if((timeNow - _qrCode.GeneratedDateTime).Seconds > 7)
            _qrCode.GenerateQRCode();

        return Code;
    }

    
    public bool IsValid(string qr) =>  qr == GetQrCode();
    
    private void GenerateQRCode()
    {
        Random random = new Random();
        Code = string.Empty;
        
        for (int i = 0; i < 5; i++)
        {
            int nr = random.Next(100000, 999999);
            Code += nr.ToString();
        }
        
        GeneratedDateTime = DateTime.Now;
    }
    
    
}