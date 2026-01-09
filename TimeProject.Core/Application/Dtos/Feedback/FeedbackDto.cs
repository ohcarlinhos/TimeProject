using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.Feedback;

public class FeedbackDto
{
    [Required] public string Message { get; set; } = "";
}