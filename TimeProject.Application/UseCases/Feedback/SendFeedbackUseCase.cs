using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.ObjectValues;
using TimeProject.Application.UseCases.Feedback.Factories;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Feedback;

public class SendFeedbackUseCase(IHookHandler hookHandler) : ISendFeedbackUseCase
{
    public async Task<ICustomResult<bool>> Handle(FeedbackDto feedbackDto, string name, string email, bool isVerified)
    {
        await hookHandler.Send(HookTo.Feedbacks,
            FeedbackFactory.Create(feedbackDto.Message, false, name, email, isVerified));

        return new CustomResult<bool> { Data = true };
    }
}