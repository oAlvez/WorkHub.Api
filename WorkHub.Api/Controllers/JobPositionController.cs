using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobPositionController(IJobPositionService _jobPositionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateJobPositionDTO dto) =>
        Created(string.Empty, await _jobPositionService.CreateAsync(dto));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateJobPositionDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da rota e do corpo não conferem.");

        var result = await _jobPositionService.UpdateAsync(dto);
        return result
            ? Ok("Cargo atualizado com sucesso.")
            : StatusCode(500, "Erro ao atualizar o cargo.");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _jobPositionService.DeleteAsync(id);
        return result
            ? Ok("Cargo excluído com sucesso.")
            : StatusCode(500, "Erro ao excluir o cargo.");
    }
}
