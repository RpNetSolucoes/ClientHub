using LibraryClienteHub.Models;

namespace LibraryClienteHub.Interface
{
    public interface IAuthServices
    {
        Task<bool> AuthenticateAsync(string userName, string password);
        Task<AuthToken> UserExists(string userName);
        Task<string> GenerateToken(int id, string userName);


    }
}
