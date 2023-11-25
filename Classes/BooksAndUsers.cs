using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class BooksAndUsers
{
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int Id { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
}