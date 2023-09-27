namespace Domain.Entities;

public class Basket
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public List<Book> Books { get; set; } = new();
}
