using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Feedbacks;

namespace TimeProject.Infrastructure.ObjectValues.Feedbacks;

public class FeedbackDto : IFeedbackDto
{
    [Required] public string Message { get; set; } = "";
}