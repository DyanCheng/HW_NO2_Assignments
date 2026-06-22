using Microsoft.EntityFrameworkCore;
using OrmApp.Models;

namespace OrmApp.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");
            entity.Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            entity.Property(b => b.Price).HasColumnName("Price").HasColumnType("numeric(18,2)");
        });
    }
}
