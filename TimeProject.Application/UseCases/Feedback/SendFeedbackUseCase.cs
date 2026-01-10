using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.UseCases.Feedback.Factories;
using TimeProject.Core.Domain.UseCases.Feedback;
using TimeProject.Core.RemoveDependencies.Dtos.Feedback;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.Feedback;

public class SendFeedbackUseCase(IHookHandler hookHandler) : ISendFeedbackUseCase
{
    public async Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, false, name, email, isVerified));

        return new Result<bool> { Data = true };
    }
}