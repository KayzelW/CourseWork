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
    public DbSet<BooksAndGenres> BooksAndGenres { get; set; }
    public DbSet<BooksAndOrders> BooksAndOrders { get; set; }
    public DbSet<Order> Orders { get; set; }

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
        modelBuilder.Entity<BooksAndGenres>().HasKey(x => new { x.BookId, x.GenreId });
        modelBuilder.Entity<BooksAndGenres>()
            .HasOne(bg => bg.Book)
            .WithMany(b => b.Genres)
            .HasForeignKey(bg => bg.BookId);

        modelBuilder.Entity<BooksAndOrders>().HasKey(x => new { x.BookId, x.OrderId });
        modelBuilder.Entity<BooksAndOrders>()
            .HasOne(bo => bo.Order)
            .WithMany(bl => bl.BookList)
            .HasForeignKey(bo => bo.OrderId);
        
    }
}