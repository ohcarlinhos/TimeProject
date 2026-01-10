using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.UseCases.Feedback.Factories;
using TimeProject.Core.RemoveDependencies.Dtos.Feedback;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.UseCases.Feedback;

namespace TimeProject.Application.UseCases.Feedback;

public class SendPublicFeedbackUseCase(IHookHandler hookHandler) : ISendPublicFeedbackUseCase
{
    public async Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, true, feedbackDto.Name, feedbackDto.Email));

        return new Result<bool> { Data = true };
    }
}