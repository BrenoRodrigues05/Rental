namespace Rental.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string username, string password);

        Task<bool> RegisterAsync(string username, string password);

        Task Logout();
    }
}
