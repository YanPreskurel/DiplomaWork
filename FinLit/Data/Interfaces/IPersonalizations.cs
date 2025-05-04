using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IPersonalizations
    {
        Task<IEnumerable<Personalization>> GetAllAsync();
        Task AddAsync(Personalization personalization);
        Task DeleteAsync(int id);
        Task<Personalization> GetByIdAsync(int id);
        Task UpdateAsync(Personalization personalization);
    }
}
