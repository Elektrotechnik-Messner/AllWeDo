namespace Schulmuseum.Models;

// Model of the database for referencing the data
public class UserModel
{
 
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Rights { get; set; }
    public string? Type { get; set; }
}