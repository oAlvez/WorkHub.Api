using Microsoft.AspNetCore.Mvc;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.Interfaces.Services;

namespace WorkHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobPositionController(IJobPositionService _jobPositionService) : ControllerBase
{
    [HttpPost(Name = "CreateJobPosition")]

    public async Task<IActionResult> Create([FromBody] CreateJobPositionDTO dto) =>
        Created(string.Empty, await _jobPositionService.CreateAsync(dto));
}
