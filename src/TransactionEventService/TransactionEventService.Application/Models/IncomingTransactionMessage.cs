namespace TransactionEventService.Application.Models;

public class IncomingTransactionMessage
{
    public string CustomerId { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public string Source { get; set; }
}