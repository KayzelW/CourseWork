using Avalonia.Controls;
using Avalonia.VisualTree;
using System;
using Classes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Visual.Events;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Visual.Views;

public partial class MainWindow : Window
{
    public AppDbContext dbContext { get; private set; }
    public User? CurrentUser { get; private set; }
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
        //var databasePath = $"Data Source={System.IO.Path.Combine(Environment.CurrentDirectory, "MyDatabase.db")}";
        var databasePath = "Host=127.0.0.1;Port=5432;Database=KRVBooks;Username=TestGroupLocalhost;Password=postgres;";
        optionsBuilder.UseNpgsql(databasePath);
        dbContext = new AppDbContext(optionsBuilder.Options)
        {
            databasepath = databasePath,
        };
        dbContext.Database.EnsureCreated();
    }

    private void AuthControl_AuthCompleted(object sender, AuthEventArgs e)
    {
        string userLogin = e.UserLogin;
        string userPassword = e.UserPassword;
        CurrentUser = dbContext.Users.Where(user => user.Login == userLogin && user.Password == userPassword).FirstOrDefault();
        if (CurrentUser == null)
        {
            authWindow_window.loginTextBox.Text = string.Empty;
            authWindow_window.passwordTextBox.Text = string.Empty;
            authWindow_window.loginTextBox.Focus();
        }
    }
}
