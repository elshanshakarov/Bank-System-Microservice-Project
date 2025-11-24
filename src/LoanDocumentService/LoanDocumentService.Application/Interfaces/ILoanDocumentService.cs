using LoanDocumentService.Application.DTOs;
using LoanDocumentService.Domain.Entities;

namespace LoanDocumentService.Application.Interfaces;

public interface ILoanDocumentService
{
    Task<LoanDocument> UploadDocumentAsync(UploadDocumentDto dto);
    Task<IEnumerable<LoanDocument>> GetDocumentsAsync(int customerId);
}