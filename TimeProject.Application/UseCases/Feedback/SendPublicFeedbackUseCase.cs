using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.ObjectValues;
using TimeProject.Application.UseCases.Feedback.Factories;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Feedback;

public class SendPublicFeedbackUseCase(IHookHandler hookHandler) : ISendPublicFeedbackUseCase
{
    public async Task<ICustomResult<bool>> Handle(PublicFeedbackDto feedbackDto)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, true, feedbackDto.Name, feedbackDto.Email));

        return new CustomResult<bool> { Data = true };
    }
}