using TimeProject.Domain.Dtos.Feedbacks;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Feedbacks;

public interface ISendPublicFeedbackUseCase
{
    ICustomResult<bool> Handle(IPublicFeedbackDto feedbackDto);
}