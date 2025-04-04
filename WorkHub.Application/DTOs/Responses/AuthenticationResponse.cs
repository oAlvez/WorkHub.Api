namespace WorkHub.Application.DTOs.Responses;
public class AuthenticationResponse
{
    public bool authenticated { get; set; }
    public string? created { get; set; }
    public string? expiration { get; set; }
    public string? accessToken { get; set; }
    public string? message { get; set; }
}