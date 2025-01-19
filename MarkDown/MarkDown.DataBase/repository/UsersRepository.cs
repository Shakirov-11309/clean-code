using MarkDown.DataBase.models;
using Microsoft.EntityFrameworkCore;

namespace MarkDown.DataBase.repository
{
    public class UsersRepository
    {
        private readonly MyDbContext _dbContext;

        public UsersRepository(MyDbContext dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Users>> GetUsers() 
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<Users> GetById(int userId) 
        {
             return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == userId);
        }

        public async Task Add(int id, string email, string password, bool is_admin) 
        {
            var userEntity = new Users
            {
                Id = id,
                Email = email,
                Password = password,
                IsAdmin = is_admin
            };

            await _dbContext.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id) 
        {
            await _dbContext.Users
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
