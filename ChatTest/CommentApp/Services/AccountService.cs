using System.Threading.Tasks;
using CommentApp.Data.Repositories;
using CommentApp.Domain.Entities;

namespace CommentApp.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _accountRepository.GetAccountByIdAsync(accountId);
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _accountRepository.GetAccountByUsernameAsync(username);
        }

        public async Task CreateAccountAsync(Account account)
        {
            await _accountRepository.CreateAccountAsync(account);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            await _accountRepository.DeleteAccountAsync(accountId);
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            return await _accountRepository.ValidateCredentialsAsync(username, password);
        }
    }
}
