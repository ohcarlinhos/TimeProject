using System.Text.Json.Serialization;
using RestSharp;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.Settings;

namespace TimeProject.Infrastructure.Integrations;

public class UserChallengeResponse
{
    [JsonPropertyName("success")] public bool Success { get; set; }
}

public class UserChallenge(TurnstileSettings turnstileSettings) : IUserChallenge
{
    private readonly RestClient _client = new("https://challenges.cloudflare.com/turnstile/v0/siteverify");

    public async Task<bool> Test(string token)
    {
        var request = new RestRequest("", Method.Post);
        request.AddJsonBody(new { secret = turnstileSettings.Secret, response = token });

        try
        {
            var response = await _client.ExecuteAsync<UserChallengeResponse>(request);
            return response.Data is { Success: true };
        }
        catch
        {
            return false;
        }
    }
}