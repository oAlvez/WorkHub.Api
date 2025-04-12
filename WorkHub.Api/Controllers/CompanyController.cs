using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService _companyService) : ControllerBase
{
    //[HttpGet("GetById/{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id)
    //{
    //    var result = await _companyService.(id);
    //    return result ? Ok("Empresa excluída com sucesso.") : StatusCode(500, "Erro ao excluir a empresa.");
    //}

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyDTO dto) =>
        Created(string.Empty, await _companyService.CreateAsync(dto));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID do corpo e da rota não conferem.");

        var result = await _companyService.UpdateAsync(dto);
        return result ? Ok("Empresa atualizada com sucesso.") : StatusCode(500, "Erro ao atualizar a empresa.");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _companyService.DeleteAsync(id);
        return result ? Ok("Empresa excluída com sucesso.") : StatusCode(500, "Erro ao excluir a empresa.");
    }
}
