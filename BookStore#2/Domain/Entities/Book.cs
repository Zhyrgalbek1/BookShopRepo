namespace Domain.Entities;

public class Book
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required int Count { get; set; }
    public required decimal Price { get; set; }
}
