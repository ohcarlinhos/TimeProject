using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Feedbacks;

public interface ISendPublicFeedbackUseCase
{
    ICustomResult<bool> Handle(IPublicFeedbackDto feedbackDto);
}