using System.Threading.Tasks;
using TUT_11_FIXED.Services;
using Microsoft.AspNetCore.Mvc;

namespace TUT_11_FIXED.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _service;
    public PatientsController(IDbService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var result = await _service.GetPatientDetailsAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}