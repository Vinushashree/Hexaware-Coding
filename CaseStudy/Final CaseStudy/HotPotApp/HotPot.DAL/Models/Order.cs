using HotPot.DAL.Models;

public class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime OrderDate { get; set; }
    public string Status { get; set; }  // e.g., Pending, Processing, Delivered

    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}

