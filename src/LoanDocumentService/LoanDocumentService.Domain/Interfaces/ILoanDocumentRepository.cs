using LoanDocumentService.Domain.Entities;

namespace LoanDocumentService.Domain.Interfaces;

public interface ILoanDocumentRepository
{
    Task AddAsync(LoanDocument document);
    Task<IEnumerable<LoanDocument>> GetByCustomerIdAsync(int customerId);
}