using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class ForecastReportRepository : IForecastReports
    {
        private readonly DbContent dbContent;
        public ForecastReportRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(ForecastReport forecastReport)
        {
            dbContent.ForecastReports.Add(forecastReport);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.ForecastReports.FindAsync(id);

            if (obj != null)
            {
                dbContent.ForecastReports.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ForecastReport>> GetAllAsync() => await dbContent.ForecastReports.ToListAsync();

        public async Task<ForecastReport> GetByIdAsync(int id)
        {
            var obj = await dbContent.ForecastReports.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"ForecastReport with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(ForecastReport forecastReport)
        {
            dbContent.ForecastReports.Update(forecastReport);
            await dbContent.SaveChangesAsync();
        }
    }
}
