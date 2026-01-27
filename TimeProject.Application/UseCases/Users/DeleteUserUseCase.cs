using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class DeleteUserUseCase(IUnitOfWork unitOfWork) : IDeleteUserUseCase
{
    public ICustomResult<bool> Handle(int id)
    {
        unitOfWork.UserRepository.Delete(id);
        unitOfWork.SaveChanges();
        return new CustomResult<bool> { Data = true };
    }
}