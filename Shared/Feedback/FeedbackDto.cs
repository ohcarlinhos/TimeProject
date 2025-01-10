using System.ComponentModel.DataAnnotations;

namespace Shared.Feedback;

public class FeedbackDto
{
    [Required] public string Message { get; set; } = "";
}