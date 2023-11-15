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

    public string databasepath;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        //var databasePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "MyDatabase.db");

        //optionsBuilder.UseSQlite($"Data Source={databasePath}");
        optionsBuilder.UseNpgsql(databasepath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Books).WithOne(b => b.User);
        modelBuilder.Entity<Book>().HasMany(x => x.Genres);
        modelBuilder.Entity<Book>().HasOne(x => x.Author);
    }
}