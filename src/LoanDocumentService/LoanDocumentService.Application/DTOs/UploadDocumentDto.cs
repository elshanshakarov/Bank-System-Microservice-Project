using Microsoft.AspNetCore.Http;

namespace LoanDocumentService.Application.DTOs;

public class UploadDocumentDto
{
    public IFormFile File { get; set; }
    public int CustomerId { get; set; }
    public string DocumentType { get; set; }
}