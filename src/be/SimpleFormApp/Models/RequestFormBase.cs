using SimpleFormApp.Database;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleFormApp.Models;

public abstract record RequestFormBase
{
    public required string Title { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required ApplicationArea ApplicationArea { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime? DateTime { get; set; }

    [RegularExpression(@"http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-]*)(&(amp;)?‌​[\w\?‌​=]*)?|(http|https)?:\/\/(www\.|player\.)?vimeo\.com\/(?:channels\/(?:\w+\/)?|groups\/([^\/]*)\/videos\/|video\/|)(\d+)(?:|\/\?)", ErrorMessage = "Only youtube and vimeo links are allowed")]
    public string? VideoUrl { get; set; }
    public bool Resolved { get; set; }

    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage = "Only email are allowed")]
    public string? ContactEmail { get; set; }

    [MinLength(1)]
    public required string[] Tags { get; set; }
}
