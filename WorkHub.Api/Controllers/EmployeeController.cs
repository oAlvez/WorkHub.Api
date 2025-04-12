using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Application.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDTO dto) =>
        Created(string.Empty, await _employeeService.CreateAsync(dto));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da rota e do corpo não conferem.");

        var result = await _employeeService.UpdateAsync(dto);
        return result
            ? Ok("Funcionário atualizado com sucesso.")
            : StatusCode(500, "Erro ao atualizar o Funcionário.");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _employeeService.DeleteAsync(id);
        return result
            ? Ok("Funcionário excluído com sucesso.")
            : StatusCode(500, "Erro ao excluir o funcionário.");
    }
}
