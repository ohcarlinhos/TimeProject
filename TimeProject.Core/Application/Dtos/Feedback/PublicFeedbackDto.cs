using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.Feedback;

public class PublicFeedbackDto : FeedbackDto
{
    [Required] public string Name { get; set; } = "";
    [Required] public string Email { get; set; } = "";
}