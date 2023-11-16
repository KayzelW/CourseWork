using Avalonia.Controls;
using Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Visual.ViewModels;

namespace Visual.Views;

public partial class MainView : UserControl
{
    public ObservableCollection<BookView> booksView { get; private set; } = new();
    public List<Book> booksData { get; set; } = new List<Book>();
    public MainView()
    {
        InitializeComponent();
        //DataContext = booksView;
              
    }

    public MainView(List<Book> books) : this()
    {
        booksData = books;

        foreach (var book in booksData)
        {
            booksView.Add(new BookView()
            {
                DataContext = book,
            });
        }
        dataView.ItemsSource = booksView;
    }
}
