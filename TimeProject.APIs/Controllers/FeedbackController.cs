using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Attributes;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Infrastructure.ObjectValues.Feedback;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/feedbacks")]
public class FeedbackController(
    ISendFeedbackUseCase sendFeedbackUseCase,
    ISendPublicFeedbackUseCase sendPublicFeedbackUseCase) : CustomController
{
    [HttpPost]
    [Authorize]
    [UserChallenge]
    public ActionResult<bool> Send(FeedbackDto feedbackDto)
    {
        return HandleResponse(sendFeedbackUseCase
            .Handle(feedbackDto, UserClaims.Name(User), UserClaims.Email(User), UserClaims.IsVerified(User)));
    }

    [HttpPost("public")]
    [UserChallenge]
    public ActionResult<bool> SendPublic(PublicFeedbackDto feedbackDto)
    {
        return HandleResponse(sendPublicFeedbackUseCase.Handle(feedbackDto));
    }
}