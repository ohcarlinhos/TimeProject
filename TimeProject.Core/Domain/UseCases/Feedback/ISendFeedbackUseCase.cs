using TimeProject.Core.RemoveDependencies.Dtos.Feedback;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Feedback;

public interface ISendFeedbackUseCase
{
    Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified);
}