using CustomerProfileService.Application.DTOs;
using CustomerProfileService.Application.Interfaces;
using CustomerProfileService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProfileService.Api.Controllers;

    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly ICustomerProfileService _service;

        public ProfileController(ICustomerProfileService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadProfileDto dto)
        {
            var result = await _service.UploadProfileAsync(dto);
            return Ok(result);
        }
    }
