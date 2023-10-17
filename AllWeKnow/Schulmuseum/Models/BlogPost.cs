namespace Schulmuseum.Models;

public class BlogPost
{
    public int? Id { get; set; }
    public int CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? TitleImage { get; set; }
    public string? Username { get; set; }
    public string? Date { get; set; }
    public string? Content { get; set; }
}