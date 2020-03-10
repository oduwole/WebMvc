using Microsoft.EntityFrameworkCore;
//using MySQL.Data.EntityFrameworkCore.Extensions;

namespace WebMvc
{
  public class LibraryContext : DbContext
  {
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
    {
        
    }
    public LibraryContext()
    {
        
    }
    public DbSet<Book> Book { get; set; }

    public DbSet<Publisher> Publisher { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("server=./;database=MVCSongsDB;user=sa;password=01032015");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Publisher>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
      });

      modelBuilder.Entity<Book>(entity =>
      {
        entity.HasKey(e => e.ISBN);
        entity.Property(e => e.Title).IsRequired();
        entity.HasOne(d => d.Publisher)
          .WithMany(p => p.Books);
      });
    }
  }
}