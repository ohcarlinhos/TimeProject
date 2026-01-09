using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Infrastructure.Attributes;
using TimeProject.Api.Infrastructure.Controllers;
using TimeProject.Core.Application.Dtos.Feedback;
using TimeProject.Core.Application.General.Util;
using TimeProject.Core.Domain.UseCases.Feedback;

namespace TimeProject.Api.Modules.Feedback;

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