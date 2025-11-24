using LoanDocumentService.Application.DTOs;
using LoanDocumentService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanDocumentService.Api.Controllers;

[ApiController]
[Route("api/loan-documents")]
public class LoanDocumentController : ControllerBase
{
    private readonly ILoanDocumentService _service;

    public LoanDocumentController(ILoanDocumentService service)
    {
        _service = service;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] UploadDocumentDto dto)
    {
        var result = await _service.UploadDocumentAsync(dto);
        return Ok(result);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> Get(int customerId)
    {
        var docs = await _service.GetDocumentsAsync(customerId);
        return Ok(docs);
    }
}