namespace Chat.BLL.Contracts;

public interface ITokenService
{
    string GenerateToken(int userId);
}