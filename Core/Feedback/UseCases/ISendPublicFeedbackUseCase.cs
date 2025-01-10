using Shared.Feedback;
using Shared.General;

namespace Core.Feedback.UseCases;

public interface ISendPublicFeedbackUseCase
{
    Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto);
}