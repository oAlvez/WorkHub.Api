using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Requests;
using WorkHub.Application.DTOs.Responses;
using WorkHub.Application.Interfaces;

namespace WorkHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request) =>
    Ok(await _authenticationService.AuthenticateAsync(request));
}
