using SimpleFormApp.Database;

namespace SimpleFormApp.Models;

public class UpdateRequestForm
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required ApplicationArea ApplicationArea { get; set; }
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }
    public string? VideoUrl { get; set; }
    public bool Resolved { get; set; }
    public DateTime DateCreated { get; set; }
    public string? ContactEmail { get; set; }
    public required string[] Tags { get; set; }
}
