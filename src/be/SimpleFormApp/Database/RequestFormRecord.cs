
using SimpleFormApp.Models;

namespace SimpleFormApp.Database;

public class RequestFormRecord
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required ApplicationArea ApplicationArea { get; set; }
    public string Description { get; set; }
    public DateTime? DateTime { get; set; }
    public string VideoUrl { get; set; }
    public bool Resolved { get; set; }
    public DateTime DateCreated { get; set; }
    public string ContactEmail { get; set; }

    public required Tag Tag { get; set; }

    public RequestForm Into()
    {
        return new RequestForm()
        {
            ApplicationArea = ApplicationArea,
            Tags = Tag.Tags,
            Title = Title,
            Id = Id,
            ContactEmail = ContactEmail,
            DateCreated = DateCreated,
            DateTime = DateCreated,
            Description = Description,
            VideoUrl = VideoUrl,
            Resolved = Resolved,
        };
    }
}

public enum ApplicationArea
{
    NA,
    Settings,
    UserManagement,
    Inventory
}
