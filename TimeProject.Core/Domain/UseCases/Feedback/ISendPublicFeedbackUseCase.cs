using TimeProject.Core.RemoveDependencies.Dtos.Feedback;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Feedback;

public interface ISendPublicFeedbackUseCase
{
    Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto);
}