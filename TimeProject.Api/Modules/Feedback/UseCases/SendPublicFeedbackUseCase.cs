using TimeProject.Core.Application.Dtos.Feedback;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Modules.Feedback.Utils;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.UseCases.Feedback;

namespace TimeProject.Api.Modules.Feedback.UseCases;

public class SendPublicFeedbackUseCase(IHookHandler hookHandler) : ISendPublicFeedbackUseCase
{
    public async Task<Result<bool>> Handle(PublicFeedbackDto feedbackDto)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, true, feedbackDto.Name, feedbackDto.Email));

        return new Result<bool> { Data = true };
    }
}