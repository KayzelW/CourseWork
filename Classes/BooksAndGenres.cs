using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class BooksAndGenres
{
    //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int Id { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}