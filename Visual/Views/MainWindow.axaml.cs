using Avalonia.Controls;
using Avalonia.VisualTree;
using System;
using Classes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Visual.Events;
using System.Linq;

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
        SQLitePCL.Batteries.Init();
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(
            $"Data Source={System.IO.Path.Combine(Environment.CurrentDirectory, "MyDatabase.db")}"
        );
        dbContext = new AppDbContext(optionsBuilder.Options);
        dbContext.Database.EnsureCreated();
    }
    
    private void AuthControl_AuthCompleted(object sender, AuthEventArgs e)
    {
        string userLogin = e.UserLogin;
        string userPassword = e.UserPassword;
        CurrentUser = dbContext.Users.Where(user => user.Login == userLogin && user.Password == userPassword).FirstOrDefault();
    }
}
