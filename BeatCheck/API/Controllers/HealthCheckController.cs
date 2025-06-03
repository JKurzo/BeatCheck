using Application.HealthCheck;
using Application.HealthCheck.DTOs;
using Application.HealthCheck.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckService _healthCheckService;
        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHealthCheck()
        {
            return Ok(await _healthCheckService.GetAllSuitesAsync());
        }

        [HttpPost("suite")]
        public async Task<IActionResult> CreateHealthCheckSuite([FromBody] CreateHealthCheckSuiteDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid health check suite data.");
            }
            var id = await _healthCheckService.CreateSuiteAsync(dto);
            return CreatedAtAction(nameof(GetAllHealthCheck), new { id }, null);
        }
    }
}
