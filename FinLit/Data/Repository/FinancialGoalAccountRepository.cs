using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Reflection.Metadata.Ecma335;

namespace FinLit.Data.Repository
{
    public class FinancialGoalAccountRepository : IFinancialGoalAccounts
    {
        private readonly DbContent dbContent;

        public FinancialGoalAccountRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public async Task AddAsync(FinancialGoalAccount financialGoalAccount)
        {
            dbContent.FinancialGoalAccounts.Add(financialGoalAccount);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.FinancialGoalAccounts.FindAsync(id);

            if(obj != null)
            {
                dbContent.FinancialGoalAccounts.Remove(obj);
            }
        }
        public async Task<IEnumerable<FinancialGoalAccount>> GetAllAsync() => await dbContent.FinancialGoalAccounts.OrderBy(fga => fga.TargetDate).ToListAsync();
        public async Task<FinancialGoalAccount> GetByIdAsync(int id)
        {
            var obj = await dbContent.FinancialGoalAccounts.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"Financial Goal Account with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(FinancialGoalAccount financialGoalAccount)
        {
            dbContent.FinancialGoalAccounts.Update(financialGoalAccount);
            await dbContent.SaveChangesAsync();
        }
    }
}
