namespace Chat.BLL.Models;

public class AuthSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public int TokenLifetime { get; set; }
}