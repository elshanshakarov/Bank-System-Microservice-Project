namespace NotificationService.Domain.Models;

public class NotificationEvent
{
    public int EventId { get; set; }
    public int CustomerId { get; set; }
    public string Type { get; set; }        // deposit / withdraw / transfer
    public decimal Amount { get; set; }
    public string Source { get; set; }      // ATM, MobileApp, WebApp
    public DateTime Timestamp { get; set; }
}