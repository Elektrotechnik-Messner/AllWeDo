namespace Schulmuseum.Authentication;

public class UserSession
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }

    public string? Role { get; set; }
}