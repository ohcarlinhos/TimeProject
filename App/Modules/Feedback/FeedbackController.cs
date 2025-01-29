using App.Infrastructure.Attributes;
using App.Infrastructure.Controllers;
using Core.Feedback.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Feedback;
using Shared.General.Util;

namespace App.Modules.Feedback;

[ApiController, Route("api/feedback")]
public class FeedbackController(
    ISendFeedbackUseCase sendFeedbackUseCase,
    ISendPublicFeedbackUseCase sendPublicFeedbackUseCase) : CustomController
{
    [HttpPost, Authorize, UserChallenge]
    public async Task<ActionResult<bool>> Send(FeedbackDto feedbackDto)
    {
        return HandleResponse(await sendFeedbackUseCase
            .Handle(feedbackDto, UserClaims.Name(User), UserClaims.Email(User), UserClaims.IsVerified(User)));
    }

    [HttpPost("public"), UserChallenge]
    public async Task<ActionResult<bool>> SendPublic(PublicFeedbackDto feedbackDto)
    {
        return HandleResponse(await sendPublicFeedbackUseCase.Handle(feedbackDto));
    }
}