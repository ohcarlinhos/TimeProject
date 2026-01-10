using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.RemoveDependencies.Dtos.Feedback;

public class FeedbackDto
{
    [Required] public string Message { get; set; } = "";
}