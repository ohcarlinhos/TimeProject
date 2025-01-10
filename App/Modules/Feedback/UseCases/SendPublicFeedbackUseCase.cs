using App.Infrastructure.Interfaces;
using App.Modules.Feedback.Utils;
using Core.Feedback.UseCases;
using Shared.Feedback;
using Shared.General;

namespace App.Modules.Feedback.UseCases;

public class SendPublicFeedbackUseCase(IHookHandler hookHandler) : ISendPublicFeedbackUseCase
{
    public async Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, true, feedbackDto.Name, feedbackDto.Email));

        return new Result<bool> { Data = true };
    }
}