using TimeProject.Infrastructure.Interfaces;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Factories;

namespace TimeProject.Application.UseCases.Feedback;

public class SendPublicFeedbackUseCase(IHookHandler hookHandler) : ISendPublicFeedbackUseCase
{
    public ICustomResult<bool> Handle(PublicFeedbackDto feedbackDto)
    {
        hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, true, feedbackDto.Name, feedbackDto.Email));

        return new CustomResult<bool> { Data = true };
    }
}