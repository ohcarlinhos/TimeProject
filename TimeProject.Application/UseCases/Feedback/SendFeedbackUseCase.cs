using TimeProject.Infrastructure.Interfaces;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Factories;
using TimeProject.Infrastructure.ObjectValues.Feedback;

namespace TimeProject.Application.UseCases.Feedback;

public class SendFeedbackUseCase(IHookHandler hookHandler) : ISendFeedbackUseCase
{
    public  ICustomResult<bool> Handle(IFeedbackDto feedbackDto, string name, string email, bool isVerified)
    {
        hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, false, name, email, isVerified));

        return new CustomResult<bool> { Data = true };
    }
}