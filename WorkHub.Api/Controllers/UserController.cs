using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;

namespace WorkHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService _userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _userService.GetByIdAsync(id));


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDTO dto)
    {
        var id = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(Create), new { id }, "Usuário criado com sucesso.");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da URL e do corpo não conferem.");

        var success = await _userService.UpdateAsync(dto);
        return success ? Ok("Usuário atualizado com sucesso.") : StatusCode(500, "Erro ao atualizar o usuário.");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _userService.DeleteAsync(id);
        return success ? Ok("Usuário deletado com sucesso.") : StatusCode(500, "Erro ao deletar o usuário.");
    }
}