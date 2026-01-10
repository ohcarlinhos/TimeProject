using System.ComponentModel.DataAnnotations;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Feedback;

public class FeedbackDto
{
    [Required] public string Message { get; set; } = "";
}