using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes;

public class User : INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public List<Book>? Books { get; set; } = new();

    public User(int id, string name, string email = "", string password = "", List<Book>? books = null) : this() => 
        (this.Id, this.Login, this.Email, this.Password, this.Books) = (id, name, email, password, books);

    public User()
    {
        
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void Dirty(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
    }
}
