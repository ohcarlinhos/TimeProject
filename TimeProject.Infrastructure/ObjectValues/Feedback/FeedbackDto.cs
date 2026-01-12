using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Feedback;

namespace TimeProject.Infrastructure.ObjectValues.Feedback;

public class FeedbackDto : IFeedbackDto
{
    [Required] public string Message { get; set; } = "";
}