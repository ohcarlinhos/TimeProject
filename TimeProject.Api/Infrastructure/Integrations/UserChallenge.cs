using System.Text.Json.Serialization;
using RestSharp;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Infrastructure.Settings;

namespace TimeProject.Api.Infrastructure.Integrations;

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