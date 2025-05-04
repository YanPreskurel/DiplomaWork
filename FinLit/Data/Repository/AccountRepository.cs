using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class AccountRepository : IAccounts
    {
        private readonly DbContent dbContent;
        public AccountRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(Account account)
        {
            dbContent.Accounts.Add(account);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Accounts.FindAsync(id);

            if (obj != null)
            {
                dbContent.Accounts.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Account>> GetAllAsync() => await dbContent.Accounts.OrderBy(a => a.Id).ToListAsync();
        public async Task<Account> GetByIdAsync(int id)
        {
            var obj = await dbContent.Accounts.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"Account with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Account account)
        {
            dbContent.Accounts.Update(account);
            await dbContent.SaveChangesAsync();
        }
    }
}
