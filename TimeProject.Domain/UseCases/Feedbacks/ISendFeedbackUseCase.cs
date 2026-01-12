using TimeProject.Domain.Dtos.Feedbacks;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Feedbacks;

public interface ISendFeedbackUseCase
{
    ICustomResult<bool> Handle(IFeedbackDto feedbackDto, string name, string email, bool isVerified);
}