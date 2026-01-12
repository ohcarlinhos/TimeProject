namespace TimeProject.Domain.RemoveDependencies.Dtos.Feedback;

public interface IPublicFeedbackDto : IFeedbackDto
{
    string Name { get; set; }
    string Email { get; set; }
}