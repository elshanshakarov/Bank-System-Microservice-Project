using LoanDocumentService.Application.DTOs;
using LoanDocumentService.Application.Interfaces;
using LoanDocumentService.Domain.Entities;
using LoanDocumentService.Domain.Interfaces;

namespace LoanDocumentService.Application.Services;

public class LoanDocumentService : ILoanDocumentService
{
    private readonly ILoanDocumentRepository _repo;
    private readonly IFileStorage _fileStorage;
    private readonly IFileValidator _validator;

    public LoanDocumentService(
        ILoanDocumentRepository repo,
        IFileStorage fileStorage,
        IFileValidator validator)
    {
        _repo = repo;
        _fileStorage = fileStorage;
        _validator = validator;
    }

    public async Task<LoanDocument> UploadDocumentAsync(UploadDocumentDto dto)
    {
        if (!_validator.IsValidFormat(dto.File))
            throw new Exception("Invalid file format.");

        if (!_validator.IsValidSize(dto.File))
            throw new Exception("File size exceeds limit.");

        var filePath = await _fileStorage.SaveAsync(dto.File);

        var doc = new LoanDocument
        {
            CustomerId = dto.CustomerId,
            DocumentType = dto.DocumentType,
            FileUrl = filePath,
            FileFormat = dto.File.ContentType,
            FileSizeKb = dto.File.Length / 1024,
            UploadedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(doc);

        return doc;
    }

    public async Task<IEnumerable<LoanDocument>> GetDocumentsAsync(int customerId)
    {
        return await _repo.GetByCustomerIdAsync(customerId);
    }
}