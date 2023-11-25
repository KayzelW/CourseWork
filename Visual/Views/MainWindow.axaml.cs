using Avalonia.Controls;
using Avalonia.VisualTree;
using System;
using Classes;
using Microsoft.EntityFrameworkCore;
using Visual.Events;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.IO;

namespace Visual.Views;

public partial class MainWindow : Window
{
    public AppDbContext dbContext { get; private set; }
    public User? CurrentUser { get; private set; }
    private MainView mainView_window;
    public MainWindow()
    {
        InitializeComponent();
        mainWindow_window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeDbContext();
        mainWindow_window.Width = authWindow_window.Width;
        mainWindow_window.Height = authWindow_window.Height;
    }

    private void InitializeDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var databasePath = $"Data Source={@"C:\Projects\CourseWork\MyDatabase.db"}";
        optionsBuilder.UseSqlite(databasePath);
        //var databasePath = "Host=127.0.0.1;Port=5432;Database=KRVBooks;Username=TestGroupLocalhost;Password=postgres;";
        //optionsBuilder.UseNpgsql(databasePath);
        dbContext = new AppDbContext(optionsBuilder.Options);

        if (dbContext.Database.EnsureCreated())
        {
            dbContext.Database.Migrate();
        }

#if DEBUG
        if (dbContext.Users.Where(u => u.Login == "root").ToList().Count == 0)
        {
            dbContext.Users.Add(new User
            {
                Id = 1,
                Books = new List<BooksAndUsers>(),
                Email = "SomeEmail@gmail.com",
                Login = "root",
                Password = "root",
            });
            dbContext.SaveChanges();
        }
        CurrentUser = dbContext.Users.Where(u => u.Login == "root").FirstOrDefault();
        if (dbContext.Authors.Where(author => author.Name == "AuthorTestName").ToList().Count == 0)
        {
            dbContext.Authors.Add(new Author { Id = 1, Name = "AuthorTestName" });
            dbContext.SaveChanges();
        }
        if (dbContext.Books.Where(book => book.Name.Contains("testbookName")).ToList().Count == 0)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Books.Add(new Book(
                    i, $"testbookName{i}", dbContext.Authors.First(), i * 100
                ));
            }
            dbContext.SaveChanges();
        }
#endif
    }

    private void AuthControl_AuthCompleted(object sender, AuthEventArgs e)
    {
        string userLogin = e.UserLogin;
        string userPassword = e.UserPassword;
        CurrentUser = dbContext.Users?.Where(user => user.Login == userLogin && user.Password == userPassword).FirstOrDefault();

        if (CurrentUser == null)
        {
            authWindow_window.loginTextBox.Text = string.Empty;
            authWindow_window.passwordTextBox.Text = string.Empty;
            authWindow_window.loginTextBox.Focus();
            return;
        }

        dockPanel.Children.Remove(authWindow_window);
        mainView_window = new MainView(dbContext.Books.ToList());
        dockPanel.Children.Add(mainView_window);
        mainWindow_window.Width = 600;
        mainWindow_window.Height = 400;
    }
}
