using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class UserRepository : IUsers
    {
        private readonly DbContent dbContent;
        public UserRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(User user)
        {
            dbContent.Add(user);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Users.FindAsync(id);

            if (obj != null)
            {
                dbContent.Users.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync() => await dbContent.Users.ToListAsync();
        public async Task<User> GetByIdAsync(int id)
        {
            var obj = await dbContent.Users.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            return obj;
        }
    }
}
