namespace API.Modules.User.Repositories
{
    public interface IUserRepository
    {
        List<Entities.User> Index(int page, int perPage, string search, string orderBy, string sort);
        int GetTotalItems(string search);
        Task<Entities.User> Create(Entities.User entity);
        Task<Entities.User> Update(Entities.User entity);
        Task<bool> Delete(int id);
        Task<Entities.User?> FindById(int id);
        Task<Entities.User?> FindByEmail(string email);
    }
}