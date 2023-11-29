using ABI.Windows.UI.Popups;
using BookDesktop.Pages;
using BookDesktop.Service;
using Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookDesktop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Environment.CurrentDirectory =
            AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                AppDomain.CurrentDomain.BaseDirectory.IndexOf("BookDesktop"));
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlite($"Data Source={Environment.CurrentDirectory + @"\MyDatabase.db"}");
        });
        builder.Services.AddSingleton<BinService>();
        var app = builder.Build();
        //Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("BookDesktop"))
        var dbContext = app.Services.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
#if DEBUG
        DbDataFill(dbContext);
#endif

        return app;
    }

    private async static void DbDataFill(AppDbContext dbContext)
    {
        await Task.Run(() =>
        {
            if (dbContext.Users.ToList().Count < 4) //root
            {
                dbContext.Users.Add(new User
                {
                    Id = 1,
                    Email = "RootEmail@gmail.com",
                    Login = "root",
                    Password = "root",
                    PermissionLvl = 0
                });
                dbContext.Users.Add(new User //admin
                {
                    Id = 2,
                    Email = "AdminEmail@gmail.com",
                    Login = "admin",
                    Password = "admin",
                    PermissionLvl = 1
                });
                dbContext.Users.Add(new User //employeer1
                {
                    Id = 3,
                    Email = "Emp1Email@gmail.com",
                    Login = "employeer1",
                    Password = "employeer1",
                    PermissionLvl = 2
                });
                dbContext.Users.Add(new User //employeer2
                {
                    Id = 4,
                    Email = "Emp2Email@gmail.com",
                    Login = "employeer2",
                    Password = "employeer2",
                    PermissionLvl = 2
                });
                dbContext.SaveChanges();
            }

            if (dbContext.Authors.Where(author => author.Name == "AuthorTestName").ToList().Count == 0) //Author
            {
                dbContext.Authors.Add(new Author { Id = 1, Name = "AuthorTestName" });
                dbContext.SaveChanges();
            }

            if (dbContext.Books.Where(book => book.Name.Contains("testbookName")).ToList().Count == 0) //Book
            {
                for (int i = 1; i <= 10; i++)
                {
                    var lastGenre = new Genre();
                    if (dbContext.Genres.Where(x => x.Id == i).FirstOrDefault() == null)
                    {
                        lastGenre = new Genre { Id = i, Name = $"{i}TestGenreName" };
                        dbContext.Genres.Add(lastGenre);
                    }

                    var book = new Book(
                        i, $"testbookName{i}", dbContext.Authors.First(), i * 100, i * 10);
                    dbContext.Books.Add(book);
                    dbContext.BooksAndGenres.Add(new BooksAndGenres()
                        { BookId = i, GenreId = i, Book = book, Genre = lastGenre });
                }

                dbContext.SaveChanges();
            }
        });
    }
}