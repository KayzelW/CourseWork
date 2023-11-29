using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class BooksAndOrders
{
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
}