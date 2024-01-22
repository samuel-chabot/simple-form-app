using SimpleFormApp.Database;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleFormApp.Models;

public class CreateRequestForm
{
    [MaxLength(100)]
    public required string Title { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required ApplicationArea ApplicationArea { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime? DateTime { get; set; }

    [RegularExpression(@"http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-]*)(&(amp;)?‌​[\w\?‌​=]*)?|http(?:s?):\/\/(?:www\.)?vimeo.com\/.*", ErrorMessage = "Only youtube and vimeo links are allowed")]
    public string? VideoUrl { get; set; }
    public bool Resolved { get; set; }
    public DateTime DateCreated { get; set; }
    public string? ContactEmail { get; set; }
    public required string[] Tags { get; set; }
}
