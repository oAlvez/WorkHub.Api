using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService _companyService) : ControllerBase
{
    [HttpPost(Name = "CreateCompany")]

    public async Task<IActionResult> Create([FromBody] CreateCompanyDTO dto) =>
        Created(string.Empty, await _companyService.CreateAsync(dto));
}
