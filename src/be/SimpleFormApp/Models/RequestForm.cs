namespace SimpleFormApp.Models;

public record RequestForm : CreateRequestForm
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
}
