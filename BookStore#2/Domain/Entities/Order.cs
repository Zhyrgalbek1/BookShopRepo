using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public required string Adress { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public List<Book> Books { get; set; } = new(); 
        public User? User { get; set; }
    }

}
