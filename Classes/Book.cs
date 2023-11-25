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
    public int? AuthorId { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public Author? Author { get; set; } = new Author
    {
        Name = "BookAuthor",
    };
    public byte[]? Image {  get; set; }
    
    public Book(int id, string name, Author author, double price) : this() =>
        (this.Id, this.Name, this.Author, this.Price) = (id, name, author, price);

    public List<BooksAndGenres> Genres { get; set; } = new();
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
