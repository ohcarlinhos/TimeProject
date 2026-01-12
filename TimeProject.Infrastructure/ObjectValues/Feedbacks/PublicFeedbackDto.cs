using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;

namespace TimeProject.Infrastructure.ObjectValues.Feedbacks;

public class PublicFeedbackDto : FeedbackDto, IPublicFeedbackDto
{
    [Required] public string Name { get; set; } = "";
    [Required] public string Email { get; set; } = "";
}