using TimeProject.Core.Application.Dtos.Feedback;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Feedback;

public interface ISendPublicFeedbackUseCase
{
    Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto);
}