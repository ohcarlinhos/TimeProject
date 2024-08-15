using API.Database;
using Microsoft.EntityFrameworkCore;
using Shared.General;

namespace API.Modules.User.Repositories
{
    public class UserRepository(ProjectContext dbContext) : IUserRepository
    {
        public List<Entities.User> Index(PaginationQuery paginationQuery)
        {
            IQueryable<Entities.User> query = dbContext.Users;

            if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
                query = SearchWhereConditional(query, paginationQuery.Search);

            if (string.IsNullOrWhiteSpace(paginationQuery.Sort) || paginationQuery.Sort == "desc")
                query = query.OrderByDescending(tr => tr.Name);
            else
                query = query.OrderBy(tr => tr.Name);

            return query.ToList();
        }

        public int GetTotalItems(PaginationQuery paginationQuery)
        {
            IQueryable<Entities.User> query = dbContext.Users;
            
            if (!string.IsNullOrWhiteSpace(paginationQuery.Search))
                query = SearchWhereConditional(query, paginationQuery.Search);
            
            return query.Count();
        }

        public async Task<Entities.User> Create(Entities.User entity)
        {
            var now = DateTime.Now.ToUniversalTime();
            entity.CreatedAt = now;
            entity.UpdatedAt = now;

            dbContext.Users.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Entities.User> Update(Entities.User entity)
        {
            entity.UpdatedAt = DateTime.Now.ToUniversalTime();

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

        public async Task<Entities.User?> FindById(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Entities.User?> FindByEmail(string email)
        {
            return await dbContext.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
        
        private static IQueryable<Entities.User> SearchWhereConditional(IQueryable<Entities.User> query, string search)
        {
            return query.Where((u) =>
                EF.Functions.Like(
                    u.Name.ToLower(),
                    $"%{search.ToLower()}%"
                )
            );
        }
    }
}