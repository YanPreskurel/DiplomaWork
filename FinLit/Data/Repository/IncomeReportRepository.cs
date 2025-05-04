using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class IncomeReportRepository : IIncomeReports
    {
        private readonly DbContent dbContent;
        public IncomeReportRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(IncomeReport incomeReport)
        {
            dbContent.IncomeReports.Add(incomeReport);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.IncomeReports.FindAsync(id);

            if (obj != null)
            {
                dbContent.IncomeReports.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IncomeReport>> GetAllAsync() => await dbContent.IncomeReports.ToListAsync();

        public async Task<IncomeReport> GetByIdAsync(int id)
        {
            var obj = await dbContent.IncomeReports.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"IncomeReport with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(IncomeReport incomeReport)
        {
            dbContent.IncomeReports.Update(incomeReport);
            await dbContent.SaveChangesAsync();
        }
    }
}
