using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public enum OrderStatus
{
    New,
    Approved,
    InDeliver,
    Completed,
    Cancelled
}

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public virtual List<Book> Books { get; set; } = new();
    public int PerformerId { get; set; }
    [ForeignKey(nameof(PerformerId))]
    public User? Performer { get; set; }
    public int LastRedactedId { get; set; }
    [ForeignKey(nameof(LastRedactedId))]
    public User? LastRedacted { get; set; }
    public OrderStatus orderStatus { get; set; }
    public Order()
    {
        
    }

    public Order(OrderStatus status,int UserId=1, params Book[] books) : this()
    {
        this.Books = books.ToList();
        this.orderStatus = status;
        this.LastRedactedId = UserId;
        this.PerformerId = UserId;
    }
}