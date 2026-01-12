namespace TimeProject.Domain.Dtos.Feedbacks;

public interface IPublicFeedbackDto : IFeedbackDto
{
    string Name { get; set; }
    string Email { get; set; }
}