using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

public class Genre
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }

    public Genre()
    {
        
    }
    
    public override string ToString()
        => Name;

    public virtual List<Book> Books { get; set; } = new();

    public override bool Equals(object? obj)
    {
        if (obj is Genre genre)
        {
            return this.Id == genre.Id;
        }
        return false;
    }
}
