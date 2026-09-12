using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderAddress> OrderAddresses => Set<OrderAddress>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<AttributeValue> AttributeValues => Set<AttributeValue>();
    public DbSet<VariantAttributeValue> VariantAttributeValues => Set<VariantAttributeValue>();

    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();
    public DbSet<Refund> Refunds => Set<Refund>();
    public DbSet<ShippingMethod> ShippingMethods => Set<ShippingMethod>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<ShipmentItem> ShipmentItems => Set<ShipmentItem>();

    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<CouponUsage> CouponUsages => Set<CouponUsage>();
    public DbSet<Promotion> Promotions => Set<Promotion>();
    public DbSet<PromotionProduct> PromotionProducts => Set<PromotionProduct>();
    public DbSet<PromotionCategory> PromotionCategories => Set<PromotionCategory>();
    public DbSet<PromotionRule> PromotionRules => Set<PromotionRule>();
    public DbSet<FlashSale> FlashSales => Set<FlashSale>();
    public DbSet<FlashSaleItem> FlashSaleItems => Set<FlashSaleItem>();

    public DbSet<LoyaltyAccount> LoyaltyAccounts => Set<LoyaltyAccount>();
    public DbSet<LoyaltyTransaction> LoyaltyTransactions => Set<LoyaltyTransaction>();
    public DbSet<ReturnRequest> ReturnRequests => Set<ReturnRequest>();
    public DbSet<ReturnItem> ReturnItems => Set<ReturnItem>();
    public DbSet<ProductReview> Reviews => Set<ProductReview>();
    public DbSet<ProductQuestion> ProductQuestions => Set<ProductQuestion>();
    public DbSet<ProductAnswer> ProductAnswers => Set<ProductAnswer>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.Entity<Category>()
            .HasOne(x => x.ParentCategory)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Product>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<ProductVariant>().HasIndex(x => x.SKU).IsUnique();
        b.Entity<Order>().HasIndex(x => x.OrderNumber).IsUnique();
        b.Entity<Coupon>().HasIndex(x => x.Code).IsUnique();

        b.Entity<Order>().Property(x => x.OrderStatus).HasConversion<string>();
        b.Entity<Order>().Property(x => x.PaymentStatus).HasConversion<string>();
        b.Entity<Order>().Property(x => x.FulfillmentStatus).HasConversion<string>();
    }
}
