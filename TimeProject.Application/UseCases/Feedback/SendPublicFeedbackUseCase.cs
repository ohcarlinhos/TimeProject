using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.UseCases.Feedback.Factories;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;

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