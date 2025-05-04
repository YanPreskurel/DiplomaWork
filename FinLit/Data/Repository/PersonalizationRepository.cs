using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class PersonalizationRepository : IPersonalizations
    {
        private readonly DbContent dbContent;
        public PersonalizationRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(Personalization personalization)
        {
            dbContent.Personalizations.Add(personalization);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Personalizations.FindAsync(id);

            if (obj != null)
            {
                dbContent.Personalizations.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Personalization>> GetAllAsync() => await dbContent.Personalizations.ToListAsync();
        public async Task<Personalization> GetByIdAsync(int id)
        {
            var obj = await dbContent.Personalizations.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Personalization with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Personalization personalization)
        {
            dbContent.Personalizations.Update(personalization);
            await dbContent.SaveChangesAsync();
        }
    }
}
