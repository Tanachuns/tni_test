using erp_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_stock.Databases;

public class SqliteDBContext(DbContextOptions<SqliteDBContext> options) : DbContext(options)
{
    public DbSet<ItemModel> Links { get; set; }
    public DbSet<CartTransactionModel> CartTransactions { get; set; }
    public DbSet<CartModel> Carts { get; set; }
    public DbSet<StockModel> Stocks { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.Price)
                .IsRequired();
        });
        
        modelBuilder.Entity<CartTransactionModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount)
                .IsRequired();
            
            entity.HasOne(c => c.Item)
                .WithMany()
                .HasForeignKey(c => c.ItemId);
        });
        modelBuilder.Entity<CartModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            
        });
        
        modelBuilder.Entity<StockModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.HasOne(c => c.Item)
                .WithMany()
                .HasForeignKey(c => c.ItemId);
            
            
        });
        
        
    }


}