using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Feedback;

public interface ISendFeedbackUseCase
{
    Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified);
}