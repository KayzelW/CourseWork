using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public List<BooksAndOrders> BookList { get; set; } = new List<BooksAndOrders>();
    
    public int PerformerId { get; set; }
    [ForeignKey(nameof(User.Id))]
    public User Performer { get; set; }

    public Order()
    {
        
    }
}