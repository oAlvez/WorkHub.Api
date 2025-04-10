using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkHub.Application.DTOs.Requests;
using WorkHub.Application.DTOs.Responses;
using WorkHub.Application.Interfaces.Repositories.Base;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;
using WorkHub.Exceptions;
using Claim = System.Security.Claims.Claim;

namespace WorkHub.Application.Services;
public class AuthenticationService(IConfiguration _configuration, UserManager<User> userManager, SignInManager<User> signInManager) : IAuthenticationService
{
    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest requestBody)
    {
        try
        {
            await ValidateUser(requestBody);
            return await GenerateTokenAuthentication(requestBody.Username);
        }
        catch (Exception e)
        {
            return new AuthenticationResponse
            {
                authenticated = false,
                message = e.InnerException?.Message ?? e.Message
            };
        }
    }

    private async Task ValidateUser(AuthenticationRequest requestBody)
    {
        if (requestBody is null || string.IsNullOrWhiteSpace(requestBody.Username))
            throw new ErrorOnValidationException("Usuário e senha não informado");

        var user = await userManager.FindByNameAsync(requestBody.Username);

        if (user is null)
            throw new ErrorOnValidationException("Usuário não encontrado");

        //if (user.Excluido)
        //    throw new ErrorOnValidationException("Usuário inativo");

        var resultadoLogin = await signInManager.CheckPasswordSignInAsync(user, requestBody.Password, false);
        if (resultadoLogin.Succeeded is false)
            throw new ErrorOnValidationException("Senha inválida");
    }

    private async Task<AuthenticationResponse> GenerateTokenAuthentication(string username)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["PrivateKey"]);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Subject = claimsIdentity,
            NotBefore = DateTime.Now,
            Expires = DateTime.Now.AddHours(2)
        };

        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(tokenDescriptor);
        var token = handler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            authenticated = true,
            created = tokenDescriptor.NotBefore?.ToString("dd/MM/yyyy HH:mm"),
            expiration = tokenDescriptor.Expires?.ToString("dd/MM/yyyy HH:mm"),
            accessToken = token,
        };
    }
}