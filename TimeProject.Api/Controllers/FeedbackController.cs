using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Api.Infrastructure.Attributes;
using TimeProject.Core.Domain.UseCases.Feedback;
using TimeProject.Core.RemoveDependencies.Dtos.Feedback;
using TimeProject.Core.RemoveDependencies.General.Util;

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