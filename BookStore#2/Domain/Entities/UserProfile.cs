namespace Domain.Entities;

public class UserProfile
{
    public long UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public User? User { get; set; }

}
