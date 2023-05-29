using System.Threading.Tasks;
using CommentApp.Data.Contexts;
using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentApp.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly QLBDSObjectContext _context;

        public AccountRepository(QLBDSObjectContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var account = await GetAccountByIdAsync(accountId);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if (account == null)
            {
                return false;
            }

            return account.Password == password;
        }
    }
}
