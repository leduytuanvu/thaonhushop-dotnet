using Microsoft.EntityFrameworkCore;

namespace ThaoNhuShop.Domain.Entities
{
    public class ThaoNhuShopDbContext : DbContext
    {
        public ThaoNhuShopDbContext(DbContextOptions<ThaoNhuShopDbContext> option) : base(option)
        {

        }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Admin> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Ward> Wards { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(u => u.Id);
                e.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.Property(u => u.Phone).IsRequired().HasColumnType("varchar(10)");
                e.Property(u => u.Password).IsRequired().HasColumnType("varchar(50)");
                e.Property(u => u.FullName).HasColumnType("nvarchar(50)");
                e.Property(u => u.Email).HasColumnType("varchar(50)");
                e.Property(u => u.Avatar).HasColumnType("varchar(max)");
                e.Property(u => u.Gender).HasColumnType("varchar(10)");
                e.Property(u => u.Status).HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Address>(e =>
            {
                e.ToTable("Address");
                e.HasKey(a => a.Id);
                e.Property(c => c.FullName).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.PhoneContact).IsRequired().HasColumnType("varchar(10)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
                e.Property(c => c.IsDefault).HasColumnType("bit");
                e.HasOne(u => u.User).WithMany(u => u.Addresses).HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<Brand>(e =>
            {
                e.ToTable("Brand");
                e.HasKey(b => b.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Logo).IsRequired().HasColumnType("varchar(max)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Image).IsRequired().HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Color>(e =>
            {
                e.ToTable("Color");
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Url).IsRequired().HasColumnType("varchar(max)");
                e.HasOne(u => u.Product).WithMany(u => u.Colors).HasForeignKey(u => u.ProductId);
            });

            modelBuilder.Entity<District>(e =>
            {
                e.ToTable("District");
                e.HasKey(d => d.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.HasOne(u => u.Province).WithMany(u => u.Districts).HasForeignKey(u => u.ProvinceId);
            });
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
                e.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
                e.Property(c => c.Status).IsRequired().HasColumnType("varchar(10)");
                e.HasOne(u => u.User).WithMany(u => u.Orders).HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(o => o.Id);
                e.HasOne(u => u.Order).WithMany(u => u.OrderDetails).HasForeignKey(u => u.OrderId);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(p => p.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
                e.HasOne(u => u.Category).WithMany(u => u.Products).HasForeignKey(u => u.CategoryId);
                e.HasOne(u => u.Brand).WithMany(u => u.Products).HasForeignKey(u => u.BrandId);

            });

            modelBuilder.Entity<ProductImage>(e =>
            {
                e.ToTable("ProductImage");
                e.HasKey(p => p.Id);
                e.Property(c => c.Url).IsRequired().HasColumnType("varchar(max)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
                e.HasOne(u => u.Product).WithMany(u => u.ProductImages).HasForeignKey(u => u.ProductId);
            });

            modelBuilder.Entity<Province>(e =>
            {
                e.ToTable("Province");
                e.HasKey(p => p.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Admin>(e =>
            {
                e.ToTable("Admin");
                e.HasKey(r => r.Id);
                e.Property(u => u.Phone).IsRequired().HasColumnType("varchar(10)");
                e.Property(u => u.Password).IsRequired().HasColumnType("varchar(50)");
                e.Property(u => u.FullName).HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Size>(e =>
            {
                e.ToTable("Size");
                e.HasKey(s => s.Id);
                e.Property(c => c.Title).IsRequired().HasColumnType("nvarchar(50)");
                e.Property(c => c.Description).HasColumnType("nvarchar(500)");
                e.HasOne(u => u.Product).WithMany(u => u.Sizes).HasForeignKey(u => u.ProductId);
            });

            modelBuilder.Entity<Ward>(e =>
            {
                e.ToTable("Ward");
                e.HasKey(w => w.Id);
                e.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
                e.HasOne(u => u.District).WithMany(u => u.Wards).HasForeignKey(u => u.DistrictId);

            });
        }
    }
}