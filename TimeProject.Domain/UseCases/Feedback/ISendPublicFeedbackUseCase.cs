using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Feedback;

public interface ISendPublicFeedbackUseCase
{
    Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto);
}