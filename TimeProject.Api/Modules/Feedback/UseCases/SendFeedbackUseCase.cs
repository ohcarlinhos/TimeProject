using Core.Feedback.UseCases;
using Shared.Feedback;
using Shared.General;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Modules.Feedback.Utils;

namespace TimeProject.Api.Modules.Feedback.UseCases;

public class SendFeedbackUseCase(IHookHandler hookHandler) : ISendFeedbackUseCase
{
    public async Task<Result<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, false, name, email, isVerified));

        return new Result<bool> { Data = true };
    }
}