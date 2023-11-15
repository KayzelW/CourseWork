using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes;

public class Book : INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = "BookName";
    public double Price { get; set; }
    public int Amount { get; set; }
    public List<Genre> Genres { get; set; } = new();
    public int? AuthorId { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }
    public int? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public Book(int id, string name, Author author, double price, int amount, List<Genre> genres) : this() =>
        (this.Id, this.Name, this.Author, this.Price, this.Amount, this.Genres) = (id, name, author, price, amount, genres);

    public Book()
    {
        
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void Dirty(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Author)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genres)));
    }
}
