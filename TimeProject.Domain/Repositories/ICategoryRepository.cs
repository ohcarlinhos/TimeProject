using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;

namespace TimeProject.Domain.Repositories;

public interface ICategoryRepository
{
    IList<ICategory> Index(int userId, bool onlyWithData);
    IList<ICategory> Index(IPaginationQuery paginationQuery, int userId);
    int GetTotalItems(IPaginationQuery paginationQuery, int userId);
    ICategory Create(ICategory entity);
    ICategory Update(ICategory entity);
    bool Delete(ICategory entity);
    ICategory? FindById(int id);
    ICategory? FindById(int id, int userId);
    ICategory? FindByName(string name, int userId);
}