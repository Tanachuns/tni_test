using erp_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace erp_stock.Databases;

public class SqliteDBContext(DbContextOptions<SqliteDBContext> options) : DbContext(options)
{
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<CartTransactionModel> CartTransactions { get; set; }
    public DbSet<CartModel> Carts { get; set; }
    public DbSet<StockModel> Stocks { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seed
        modelBuilder.Entity<ItemModel>().HasData(
            new ItemModel { Id = 1, Name = "Wireless Mouse", Price = 990.00m },
            new ItemModel { Id = 2, Name = "Mechanical Keyboard", Price = 2970.00m },
            new ItemModel { Id = 3, Name = "27-inch 4K Monitor", Price = 11500.00m },
            new ItemModel { Id = 4, Name = "Wireless Headphones", Price = 4250.00m },
            new ItemModel { Id = 5, Name = "USB-C Hub", Price = 1480.00m }
        );
        
        modelBuilder.Entity<StockModel>().HasData(
            new StockModel { Id = 1, ItemId = 1, Amount = 50 },
            new StockModel { Id = 2, ItemId = 2, Amount = 25 },
            new StockModel { Id = 3, ItemId = 3, Amount = 10 },
            new StockModel { Id = 4, ItemId = 4, Amount = 30 },
            new StockModel { Id = 5, ItemId = 5, Amount = 100 }
        );
        #endregion
   
        
        modelBuilder.Entity<ItemModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.Price)
                .IsRequired();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
        });
        
       
        
        modelBuilder.Entity<CartTransactionModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount)
                .IsRequired();
            
            entity.HasOne(c => c.Item)
                .WithMany()
                .HasForeignKey(c => c.ItemId);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
        modelBuilder.Entity<CartModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
        });
        
        modelBuilder.Entity<StockModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.HasOne(c => c.Item)
                .WithMany()
                .HasForeignKey(c => c.ItemId);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            
        });
    }
}