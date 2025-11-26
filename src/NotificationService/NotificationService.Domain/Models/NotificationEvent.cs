namespace NotificationService.Domain.Models;

public class NotificationEvent
{
    public string EventId { get; set; }
    public string CustomerId { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}