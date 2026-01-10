using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Feedback;

public interface ISendFeedbackUseCase
{
    Task<ICustomResult<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified);
}