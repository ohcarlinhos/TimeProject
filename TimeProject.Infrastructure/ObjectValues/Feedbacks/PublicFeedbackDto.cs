using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Feedbacks;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Feedbacks;

public class PublicFeedbackDto : FeedbackDto, IPublicFeedbackDto
{
    [Required] public string Name { get; set; } = "";
    [Required] public string Email { get; set; } = "";
}