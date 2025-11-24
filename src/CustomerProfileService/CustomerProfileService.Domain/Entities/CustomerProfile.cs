namespace CustomerProfileService.Domain.Entities;

public class CustomerProfile
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
    public string PhotoFormat { get; set; }
    public long PhotoSizeKb { get; set; }
    public DateTime CreatedAt { get; set; }
}