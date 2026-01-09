using TimeProject.Core.Application.Dtos.Feedback;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Modules.Feedback.Utils;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.UseCases.Feedback;

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