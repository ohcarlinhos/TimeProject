using Shared.General;

namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        List<Entities.User> Index(PaginationQuery paginationQuery);
        int GetTotalItems(PaginationQuery paginationQuery);
        Task<Entities.User> Create(Entities.User entity);
        Task<Entities.User> Update(Entities.User entity);
        Task<bool> Delete(int id);
        Task<Entities.User?> FindById(int id);
        Task<Entities.User?> FindByEmail(string email);
    }
}