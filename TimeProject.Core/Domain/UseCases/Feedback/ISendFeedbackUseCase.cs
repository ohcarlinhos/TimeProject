using TimeProject.Core.Application.Dtos.Feedback;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Feedback;

public interface ISendFeedbackUseCase
{
    Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified);
}