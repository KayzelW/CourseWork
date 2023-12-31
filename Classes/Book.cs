﻿using System.ComponentModel;
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
    public Author? Author { get; set; } = null;
    public byte[]? Image { get; set; }
    public int Amount { get; set; } = 0;
    public virtual List<Genre> Genres { get; set; } = new();
    public virtual List<Order> Orders { get; set; } = new();
    public int LastRedactorId { get; set; }

    public Book(int id, string name, Author author, double price, int amount) : this() =>
        (this.Id, this.Name, this.Author, this.Price, this.Amount) = (id, name, author, price, amount);
    
    public Book()
    {
        
    }

    public Book(Book book)
    {
        Name = book.Name;
        AuthorId = book.AuthorId;
        LastRedactorId = book.LastRedactorId;
        Genres.AddRange(book.Genres);
        Price = book.Price;
        Amount = book.Amount;
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
