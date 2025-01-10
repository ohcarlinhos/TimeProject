using Shared.Feedback;
using Shared.General;

namespace Core.Feedback.UseCases;

public interface ISendFeedbackUseCase
{
    Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified);
}