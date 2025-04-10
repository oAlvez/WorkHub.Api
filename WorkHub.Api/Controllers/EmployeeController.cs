using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
{
    [HttpPost(Name = "CreateEmployee")]

    public async Task<IActionResult> Create([FromBody] CreateEmployeeDTO dto) =>
        Created(string.Empty, await _employeeService.CreateAsync(dto));
}
