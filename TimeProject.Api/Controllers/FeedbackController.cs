using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Attributes;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Domain.UseCases.Feedback;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/feedbacks")]
public class FeedbackController(
    ISendFeedbackUseCase sendFeedbackUseCase,
    ISendPublicFeedbackUseCase sendPublicFeedbackUseCase) : CustomController
{
    [HttpPost]
    [Authorize]
    [UserChallenge]
    public async Task<ActionResult<bool>> Send(FeedbackDto feedbackDto)
    {
        return HandleResponse(await sendFeedbackUseCase
            .Handle(feedbackDto, UserClaims.Name(User), UserClaims.Email(User), UserClaims.IsVerified(User)));
    }

    [HttpPost("public")]
    [UserChallenge]
    public async Task<ActionResult<bool>> SendPublic(PublicFeedbackDto feedbackDto)
    {
        return HandleResponse(await sendPublicFeedbackUseCase.Handle(feedbackDto));
    }
}