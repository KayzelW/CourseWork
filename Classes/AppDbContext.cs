using Microsoft.EntityFrameworkCore;

namespace Classes;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected AppDbContext()
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Log> Logs { get; set; }

    //public string databasepath = $"Data Source={@"C:\Projects\CourseWork\MyDatabase.db"}";
    //"Host=127.0.0.1;Port=5432;Database=KRVBooks;Username=TestGroupLocalhost;Password=postgres;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        //var databasePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "MyDatabase.db");

        //optionsBuilder.UseSQlite($"Data Source={databasePath}");
        //optionsBuilder.UseNpgsql(databasepath);
        //optionsBuilder.UseSqlite(databasepath);   
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(bg => bg.Books);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Books)
            .WithMany(b => b.Orders);

        modelBuilder.Entity<User>()
            .HasMany(x => x.Logs)
            .WithOne(b => b.User);
    }
}