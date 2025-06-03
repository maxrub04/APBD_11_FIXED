using TUT_11_FIXED.DTOs;
using TUT_11_FIXED.Models;
using TUT_11_FIXED.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TUT_11_FIXED.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _service;
    public PrescriptionsController(IDbService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] AddPrescriptionRequest request)
    {
        try
        {
            await _service.AddPrescriptionAsync(request);
            return Created();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}