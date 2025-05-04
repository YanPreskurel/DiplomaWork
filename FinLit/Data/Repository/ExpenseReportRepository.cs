using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class ExpenseReportRepository : IExpenseReports
    {
        private readonly DbContent dbContent;
        public ExpenseReportRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(ExpenseReport expenseReport)
        {
            dbContent.ExpenseReports.Add(expenseReport);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.ExpenseReports.FindAsync(id);

            if(obj != null)
            {
                dbContent.ExpenseReports.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseReport>> GetAllAsync() => await dbContent.ExpenseReports.ToListAsync();

        public async Task<ExpenseReport> GetByIdAsync(int id)
        {
            var obj = await dbContent.ExpenseReports.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"ExpenseReport with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(ExpenseReport expenseReport)
        {
            dbContent.ExpenseReports.Update(expenseReport);
            await dbContent.SaveChangesAsync();
        }
    }
}
