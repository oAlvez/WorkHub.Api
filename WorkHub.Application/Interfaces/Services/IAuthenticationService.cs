using WorkHub.Application.DTOs.Requests;
using WorkHub.Application.DTOs.Responses;

namespace WorkHub.Application.Interfaces.Services;
public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest requestBody);
}