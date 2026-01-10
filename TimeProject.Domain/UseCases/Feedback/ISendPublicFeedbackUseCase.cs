using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Feedback;

public interface ISendPublicFeedbackUseCase
{
    Task<ICustomResult<bool>> Handle(PublicFeedbackDto feedbackDto);
}