using System.Threading.Tasks;
using CommentApp.Domain.Entities;

namespace CommentApp.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}
