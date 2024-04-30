using API.Data;
using API.Modules.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.User.Repositories
{
    public class UserRepository(ProjectContext dbContext) : IUserRepository
    {
        public async Task<UserEntity> Create(UserEntity entity)
        {
            dbContext.Users.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            dbContext.Users.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await FindById(id);
            if (entity == null) return true;

            dbContext.Users.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserEntity?> FindById(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<UserEntity?> FindByEmail(string email)
        {
            return await dbContext.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}